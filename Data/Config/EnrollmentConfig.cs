using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Config
{
    public class EnrollmentConfig : IEntityTypeConfiguration<EnrollmentEntity>
    {
        public void Configure(EntityTypeBuilder<EnrollmentEntity> builder)
        {
            builder.ToTable(nameof(EnrollmentEntity));
            builder.HasKey(x => x.IdEnrollment);
        }
    }
}
