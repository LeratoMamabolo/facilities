using Microsoft.AspNetCore.Identity;

namespace OnlineBookingFacility.Infrastructure
{
    public class CustomUserValidator : IUserValidator<IdentityUser>
    {
        private static readonly string[] _allowedDomains = new[] { "gmail.com", "ufs.ac.za", "example.com" };
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager,
            IdentityUser user)
        {
            if (_allowedDomains.Any(domain => user.Email.ToLower().EndsWith($"@{domain}")))
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "Email address domain not allowed"
                }));
            }
        }
    }
}
