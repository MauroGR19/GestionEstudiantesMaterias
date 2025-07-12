using AutoMapper;
using Data.Entity;
using Domain.Model;
using GestionEstudiantesMaterias.Models;

namespace GestionEstudiantesMaterias.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDto, StudentModel>().ReverseMap();
            CreateMap<SubjectDto, SubjectModel>().ReverseMap();
            CreateMap<EnrollmentDto, EnrollmentModel>().ReverseMap();
        }
    }
}
