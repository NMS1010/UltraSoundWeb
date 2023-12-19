using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UltraSoundWeb.Repositories.Context.Configuration
{
    public class SpecializedConfiguration : IEntityTypeConfiguration<Entities.Specialized>
    {
        public void Configure(EntityTypeBuilder<Entities.Specialized> builder)
        {
            builder.HasData(new Entities.Specialized()
            {
                Id = 1,
                Name = "Bác sĩ siêu âm"
            }, new Entities.Specialized()
            {
                Id = 2,
                Name = "Bác sĩ chỉ định"
            }, new Entities.Specialized()
            {
                Id = 3,
                Name = "Bác sĩ kê toa"
            }, new Entities.Specialized()
            {
                Id = 4,
                Name = "Bác sĩ quản lý"
            });
        }
    }
}
