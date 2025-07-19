using Data_Logic_Layer.Data;
using Data_Logic_Layer.Repository;
using Data_Logic_Layer.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Heplers
{
    public static class ServiceApplication
    {
        public static void AddServiceApplication(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (context != null && context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
