using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
