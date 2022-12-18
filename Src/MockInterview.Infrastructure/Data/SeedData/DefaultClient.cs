using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockInterview.Infrastructure.Data.SeedData
{
    public class DefaultClient : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(new Client
            {
                Id = Guid.Parse("9f71e85f-b543-4a8f-94b9-95ded10895c4"),
                FirstName = "Client",
                LastName = "Client",
                Level = Level.None,
                Login = "client1",
                Password = "client1",
                PhoneNumber = "+998901234567",
            });
        }
    }
    public class DefaultCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("d0235e1f-76e0-40f1-a16a-1e5cfd3f9191"),
                Name = "DOT-NET",
                Description = "Professional"
            });
        }
    }

    public class DefaultInterview : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasData(new Interview
            {
              Id = Guid.Parse("d4658d58-b2e3-4fd3-9905-faa634df0083"),
              ClientId = Guid.Parse("9f71e85f-b543-4a8f-94b9-95ded10895c4"),
              CategoryId = Guid.Parse("d0235e1f-76e0-40f1-a16a-1e5cfd3f9191"),
              EployeId = Guid.Parse("a0e8ec95-b538-4cb8-af91-254648629a04"),
              Level = Level.Junior,
              Price = 100,
              LinkInterview = "youtobe.com"
            });
        }
    }
}
