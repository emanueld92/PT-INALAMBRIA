using Inalambria.Domino.Core.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Inalambria.Domino.Api.Data
{
    public static class InitDbExtensions
    {
        public static IApplicationBuilder InitDb(this WebApplication app)
        {

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager = services.GetService<UserManager<User>>();

                var roleManager = services.GetService<RoleManager<Role>>();

                if (userManager.Users.Count() == 0)
                {
                    Task.Run(() => InitRoles(roleManager)).Wait();
                    Task.Run(() => InitUsers(userManager)).Wait();
                }

            }


            return app;
        }

        private static async Task InitRoles(RoleManager<Role> roleManager)
        {
            try
            {
                var role = new Role("Admin");
                await roleManager.CreateAsync(role);

              
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private static async Task InitUsers(UserManager<User> userManager)
        {
            var user = new User()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                LastName = "Admi",
                Name = "Admin",
                PhoneNumber = "123456789"
            };
            await userManager.CreateAsync(user, "Domino.1234$");
            await userManager.AddToRoleAsync(user, "Admin");


        }
    }
}