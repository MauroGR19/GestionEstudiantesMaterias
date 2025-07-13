using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class SubjectEntity
    {
        [Key]
        public int Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public int Credits { get; set; }
        public IList<EnrollmentEntity> Enrollments { get; set; }
    }
}
