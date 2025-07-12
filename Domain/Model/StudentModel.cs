using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class StudentModel
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public StudentModel()
        {
            Document = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
        }
    }
}
