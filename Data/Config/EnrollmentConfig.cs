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
    public class EnrollmentConfig : IEntityTypeConfiguration<EnrollmentEntity>
    {
        public void Configure(EntityTypeBuilder<EnrollmentEntity> builder)
        {
            builder.ToTable(nameof(EnrollmentEntity));
            builder.HasKey(x => x.IdEnrollment);
        }
    }
}
