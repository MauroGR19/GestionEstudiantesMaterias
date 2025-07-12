using Aplication.Interface;
using AutoMapper;
using Domain.Master;
using Domain.Model;
using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using static Domain.Master.BaseMessage;

namespace GestionEstudiantesMaterias.Service
{
    public class ClsEnrollmentServ : IEnrollmentService<EnrollmentDto, int>
    {
        private readonly IUseCaseEnrollment<EnrollmentModel, int> useCaseBase;
        private ExceptionConfig exception = new ExceptionConfig();
        private readonly IMapper _mapper;
        public ClsEnrollmentServ(IUseCaseEnrollment<EnrollmentModel, int> _useCaseBase, IMapper mapper)
        {
            useCaseBase = _useCaseBase;
            _mapper = mapper;
        }

        public bool Delete(int entityID)
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

        public List<EnrollmentDto> GetAll()
        {
            try
            {
                List<EnrollmentDto> enrollments = _mapper.Map<List<EnrollmentDto>>(useCaseBase.GetAll());
                return enrollments;
            }
            catch (Exception ex)
            {
                throw exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription());
            }
        }

        public EnrollmentDto GetByID(int entityID)
        {
            try
            {
                EnrollmentDto enrollment = _mapper.Map<EnrollmentDto>(useCaseBase.GetAll());
                return enrollment;
            }
            catch (Exception ex)
            {
                throw exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription());
            }
        }

        public bool Insert(EnrollmentDto entity)
        {
            try
            {
                var result = useCaseBase.Insert(_mapper.Map<EnrollmentModel>(entity));
                return result;
            }
            catch (Exception ex)
            {

                throw exception.Error(ex, ErrorStatus.Insert.GetEnumDescription());
            }
        }
    }
}
