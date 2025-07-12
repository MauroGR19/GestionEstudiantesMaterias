using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class EnrollmentModel
    {
        public int IdEnrollment { get; set; }
        public string Document { get; set; }
        public int Code { get; set; }

        public EnrollmentModel() 
        {
            IdEnrollment = 0;
            Document = string.Empty;
            Code = 0;
        }
    }
}
