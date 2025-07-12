using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class SubjectConfig : IEntityTypeConfiguration<SubjectEntity>
    {
        public void Configure(EntityTypeBuilder<SubjectEntity> builder)
        {
            builder.ToTable(nameof(SubjectEntity));
            builder.HasKey(x => x.Code);

            builder
            .HasMany<EnrollmentEntity>(oRow => oRow.Enrollments)
            .WithOne(oItem => oItem.Subject)
            .HasForeignKey(c => c.Code);
        }
    }
}
