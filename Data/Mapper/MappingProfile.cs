using AutoMapper;
using Data.Entity;
using Domain.Model;

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
