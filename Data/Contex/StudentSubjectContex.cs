using Data.Config;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Contex
{
    public class StudentSubjectContex : DbContext
    {
        public DbSet<StudentEntity> student { get; set; }
        public DbSet<SubjectEntity> subject { get; set; }
        public DbSet<EnrollmentEntity> enrollment { get; set; }

        public StudentSubjectContex(DbContextOptions<StudentSubjectContex> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new StudentConfig());
            builder.ApplyConfiguration(new SubjectConfig());
            builder.ApplyConfiguration(new EnrollmentConfig());

        }
    }
}
