using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SubjectModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public SubjectModel()
        {
            Code = 0;
            Name = string.Empty;
            Credits = 0;
        }
    }
}
