using Aplication.Interface;
using Domain.Interface.Repository;
using Domain.Master;
using Domain.Model;
using System.ComponentModel.DataAnnotations;
using static Domain.Master.BaseMessage;

namespace Aplication.UseCase
{
    public class EnrollmentUseCase : IUseCaseEnrollment<EnrollmentModel, int>
    {
        #region Attributes
        private readonly IEnrollmentRepo<EnrollmentModel, int> repo;
        private readonly IUseCaseBase<SubjectModel, int> subjests;
        private ExceptionConfig exception = new ExceptionConfig();
        #endregion

        #region Constructors
        public EnrollmentUseCase(IEnrollmentRepo<EnrollmentModel, int> _repo, IUseCaseBase<SubjectModel, int> _subjests)
        {
            repo = _repo;
            subjests = _subjests;
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

        public List<EnrollmentModel> GetAll(string Document)
        {
            try
            {
                return repo.GetAll(Document);
            }
            catch (Exception ex)
            {
                throw new Exception(exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription()));
            }
        }

        public EnrollmentModel GetByID(string Document, int Code)
        {
            try
            {
                return repo.GetByID(Document, Code);
            }
            catch (Exception ex)
            {
                throw new Exception(exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription()));
            }
        }

        public bool Insert(EnrollmentModel entity)
        {
            try
            {
                if (ValidateEnrollment(entity))
                {
                    var result = repo.Insert(entity);
                    repo.SaveAll();
                    return result;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(exception.Error(ex, ErrorStatus.Insert.GetEnumDescription()));
            }
        }

        private bool ValidateEnrollment(EnrollmentModel entity)
        {
            var existingEnrollment = GetByID(entity.Document, entity.Code);
            if (existingEnrollment != null)
                throw new ValidationException(AdditionalError.ValidadeSubjectRepeated.GetEnumDescription());

            var enrollments = GetAll(entity.Document);

            foreach (var enrollment in enrollments)
                enrollment.Subject = subjests.GetByID(enrollment.Code);

            var subject = subjests.GetByID(entity.Code);

            bool exceedsCreditLimit = subject.Credits > 4 &&
                                      enrollments.Count(e => e.Subject.Credits > 4) >= 3;

            if (exceedsCreditLimit)
                throw new ValidationException(AdditionalError.ValidateLimitCredits.GetEnumDescription());

            return true;
        } 
        #endregion

    }
}
