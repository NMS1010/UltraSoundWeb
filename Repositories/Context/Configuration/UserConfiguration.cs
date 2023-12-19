using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraSoundWeb.Common.Enums;

namespace UltraSoundWeb.Repositories.Context.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Entities.User>
    {
        public void Configure(EntityTypeBuilder<Entities.User> builder)
        {
            builder.HasData(new Entities.User()
            {
                Id = 1,
                Password = "i2yBMU+FxDo=", // 123456
                Username = "admin",
                Role = ROLE.ADMIN
            });
        }
    }
}