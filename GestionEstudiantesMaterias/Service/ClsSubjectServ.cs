using Aplication.Interface;
using AutoMapper;
using Domain.Master;
using Domain.Model;
using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using static Domain.Master.BaseMessage;

namespace GestionEstudiantesMaterias.Service
{
    public class ClsSubjectServ : IBaseService<SubjectDto, int>
    {
        #region Attributes
        private readonly IUseCaseBase<SubjectModel, int> useCaseBase;
        private ExceptionConfig exception = new ExceptionConfig();
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ClsSubjectServ(IUseCaseBase<SubjectModel, int> _useCaseBase, IMapper mapper)
        {
            useCaseBase = _useCaseBase;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public bool Delete(int entityID)
        {
            try
            {
                var result = useCaseBase.Delete(entityID);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(exception.Error(ex, ErrorStatus.Delete.GetEnumDescription()));
            }
        }

        public List<SubjectDto> GetAll()
        {
            try
            {
                List<SubjectDto> students = _mapper.Map<List<SubjectDto>>(useCaseBase.GetAll());
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription()));
            }
        }

        public SubjectDto GetByID(int entityID)
        {
            try
            {
                SubjectDto student = _mapper.Map<SubjectDto>(useCaseBase.GetByID(entityID));
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription()));
            }
        }

        public bool Insert(SubjectDto entity)
        {
            try
            {
                var result = useCaseBase.Insert(_mapper.Map<SubjectModel>(entity));
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(exception.Error(ex, ErrorStatus.Insert.GetEnumDescription()));
            }
        }

        public bool Update(SubjectDto entity)
        {
            try
            {
                var result = useCaseBase.Update(_mapper.Map<SubjectModel>(entity));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(exception.Error(ex, ErrorStatus.Update.GetEnumDescription()));
            }
        } 
        #endregion
    }
}
