using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.ToTable(nameof(StudentEntity));
            builder.HasKey(x => x.Document);

            builder
            .HasMany<EnrollmentEntity>(oRow => oRow.Enrollments)
            .WithOne(oItem => oItem.Student)
            .HasForeignKey(c => c.Document);
        }
    }
}
