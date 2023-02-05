using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    UserName = "Bakir",
                    Email = "bakir@gmail.com"
                };

                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}