using Aplication.Interface;
using AutoMapper;
using Data.Entity;
using Domain.Interface;
using Domain.Interface.Repository;
using Domain.Master;
using Domain.Model;
using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using System;
using static Domain.Master.BaseMessage;

namespace GestionEstudiantesMaterias.Service
{
    public class ClsStudentServ : IBaseService<StudentDto, string>
    {
        private readonly IUseCaseBase<StudentModel, string> useCaseBase;
        private ExceptionConfig exception = new ExceptionConfig();
        private readonly IMapper _mapper;
        public ClsStudentServ(IUseCaseBase<StudentModel, string> _useCaseBase, IMapper mapper)
        {
            useCaseBase = _useCaseBase;
            _mapper = mapper;
        }

        public bool Delete(string entityID)
        {
            try
            {
                var result = useCaseBase.Delete(entityID);
                return result;
            }
            catch (Exception ex)
            {
                throw exception.Error(ex, ErrorStatus.Delete.GetEnumDescription());
            }
        }

        public List<StudentDto> GetAll()
        {
            try
            {
                List<StudentDto> students = _mapper.Map<List<StudentDto>>(useCaseBase.GetAll());
                return students;
            }
            catch (Exception ex)
            {
                throw exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription());
            }
        }

        public StudentDto GetByID(string entityID)
        {
            try
            {
                StudentDto student = _mapper.Map<StudentDto>(useCaseBase.GetByID(entityID));
                return student;
            }
            catch (Exception ex)
            {
                throw exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription());
            }
        }

        public bool Insert(StudentDto entity)
        {
            try
            {
                var result = useCaseBase.Insert(_mapper.Map<StudentModel>(entity));
                return result;
            }
            catch (Exception ex)
            {

                throw exception.Error(ex, ErrorStatus.Insert.GetEnumDescription());
            }
        }

        public bool Update(StudentDto entity)
        {
            try
            {
                useCaseBase.Update(_mapper.Map<StudentModel>(entity));
                return true;
            }
            catch (Exception ex)
            {
                throw exception.Error(ex, ErrorStatus.Update.GetEnumDescription());
            }
        }
    }
}
