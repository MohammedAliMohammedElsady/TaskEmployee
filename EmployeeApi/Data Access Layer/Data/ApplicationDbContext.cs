using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data_Logic_Layer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set;  }
    }
}
