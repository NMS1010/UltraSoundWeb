using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UltraSoundWeb.Repositories.Context.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Entities.Doctor>
    {
        public void Configure(EntityTypeBuilder<Entities.Doctor> builder)
        {
            builder.HasData(new Entities.Doctor()
            {
                Id = 1,
                Name = "Doctor Admin",
                UserId = 1,
                SpecializedId = 4
            });
        }
    }
}
