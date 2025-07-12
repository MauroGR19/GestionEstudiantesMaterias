using Data.Config;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    //options.UseSqlServer("Data Source=LAPTOP-B0U91KVL\\SQLEXPRESS;Initial Catalog=Tareas;Integrated Security=false;User ID=userTarea;Password=tarea2024.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

        //    //IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        //    //IConfigurationRoot root = builder.Build();

        //    //options.UseSqlServer(root["ConnectionStrings:CityDiscover"]);
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new StudentConfig());
            builder.ApplyConfiguration(new SubjectConfig());
            builder.ApplyConfiguration(new EnrollmentConfig());

        }
    }
}
