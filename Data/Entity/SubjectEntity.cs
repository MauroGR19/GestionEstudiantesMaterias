using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
