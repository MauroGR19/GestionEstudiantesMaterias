using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class StudentEntity
    {
        [Key]
        [StringLength(100)]
        public string Document { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public IList<EnrollmentEntity> Enrollments { get; set; }
    }
}
