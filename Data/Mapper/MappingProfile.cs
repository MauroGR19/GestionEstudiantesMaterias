using AutoMapper;
using Data.Entity;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentModel, StudentEntity>().ReverseMap();
            CreateMap<SubjectModel, SubjectEntity>().ReverseMap();
            CreateMap<EnrollmentModel, EnrollmentEntity>().ReverseMap();

        }
    }

}
