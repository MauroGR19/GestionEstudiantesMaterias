using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class EnrollmentEntity
    {
        [Key]
        public int IdEnrollment { get; set; }
        [StringLength(100)]
        public string Document { get; set; }
        public int Code { get; set; }
        public StudentEntity Student { get; set; }
        public SubjectEntity Subject { get; set; }
    }
}
