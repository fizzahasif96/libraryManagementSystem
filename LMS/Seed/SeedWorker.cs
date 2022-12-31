using LMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityProvider.Seed
{
    public class SeedWorker : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public SeedWorker(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var connectionString = _configuration.GetValue(typeof(string), "DefaultConnection")?.ToString() ?? _configuration.GetConnectionString("DefaultConnection");

            //await context.Database.EnsureCreatedAsync(cancellationToken);

            await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
            var roles = context.Roles.ToList();
            var alreadyCreatedRoles = context.Roles.Any();
            if (!alreadyCreatedRoles)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
