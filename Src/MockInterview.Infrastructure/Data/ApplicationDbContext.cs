using Microsoft.EntityFrameworkCore;
using MockInterview.Domain.Entities;
using MockInterview.Infrastructure.Data.SeedData;

namespace MockInterview.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DefaultEmployee());

            base.OnModelCreating(modelBuilder); 
        }

    }
}
