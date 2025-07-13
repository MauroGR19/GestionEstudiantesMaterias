using Aplication.Interface;
using Domain.Interface.Repository;
using Domain.Master;
using Domain.Model;
using static Domain.Master.BaseMessage;

namespace Aplication.UseCase
{
    public class SubjectUseCase : IUseCaseBase<SubjectModel, int>
    {
        #region Attributes
        private readonly IRepoBase<SubjectModel, int> repo;
        private ExceptionConfig exception = new ExceptionConfig();
        #endregion

        #region Constructors
        public SubjectUseCase(IRepoBase<SubjectModel, int> _repo)
        {
            repo = _repo;
        }
        #endregion

        #region Methods
        public bool Delete(int entityID)
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

        public List<SubjectModel> GetAll()
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

        public SubjectModel GetByID(int entityID)
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

        public bool Insert(SubjectModel entity)
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

        public bool Update(SubjectModel entity)
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
