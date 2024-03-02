using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineBookingFacility.Data;
using OnlineBookingFacility.Models;
using Stripe;

namespace OnlineBookingFacility
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public class StripeSettings
        {
            public string SecretKey { get; set; }
            public string PublishableKey { get; set; }
        }
        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddControllersWithViews();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
        }

        
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Booking}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=PDF}/{action=Index}/{id?}");
            });

        }

    }
}
