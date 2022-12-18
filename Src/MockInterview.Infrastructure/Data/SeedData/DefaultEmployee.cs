using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Enums;

namespace MockInterview.Infrastructure.Data.SeedData
{
    public class DefaultEmployee : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Nodirxon",
                LastName = "Abdumurotov",
                Role = Role.Admin,
                CreatedBy = Guid.Empty,
                CreatedDate = DateTime.Now,
                Level = Level.None,
                Login = "admin",
                Password = "admin",
                PhoneNumber = "1111",
            });
        }
    }
}
