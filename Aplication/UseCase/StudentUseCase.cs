using Aplication.Interface;
using Domain.Interface.Repository;
using Domain.Master;
using Domain.Model;
using static Domain.Master.BaseMessage;

namespace Aplication.UseCase
{
    public class StudentUseCase : IUseCaseBase<StudentModel, string>
    {
        #region Attributes
        private readonly IRepoBase<StudentModel, string> repo;
        private ExceptionConfig exception = new ExceptionConfig();
        #endregion

        #region Constructors
        public StudentUseCase(IRepoBase<StudentModel, string> _repo)
        {
            repo = _repo;
        }
        #endregion

        #region Methods
        public bool Delete(string entityID)
        {
            try
            {
                var result = repo.Delete(entityID);
                repo.SaveAll();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(exception.Error(ex, ErrorStatus.Delete.GetEnumDescription()));
            }
        }

        public List<StudentModel> GetAll()
        {
            try
            {
                return repo.GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception(exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription()));
            }
        }

        public StudentModel GetByID(string entityID)
        {
            try
            {
                return repo.GetByID(entityID);
            }
            catch (Exception ex)
            {

                throw new Exception(exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription()));
            }
        }

        public bool Insert(StudentModel entity)
        {
            try
            {
                var result = repo.Insert(entity);
                repo.SaveAll();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(exception.Error(ex, ErrorStatus.Insert.GetEnumDescription()));
            }
        }

        public bool Update(StudentModel entity)
        {
            try
            {
                var result = repo.Update(entity);
                repo.SaveAll();
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
