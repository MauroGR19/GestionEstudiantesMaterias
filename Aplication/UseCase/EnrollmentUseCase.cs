using Aplication.Interface;
using Domain.Interface.Repository;
using Domain.Master;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using static Domain.Master.BaseMessage;

namespace Aplication.UseCase
{
    public class EnrollmentUseCase : IUseCaseEnrollment<EnrollmentModel, int>
    {
        private readonly IEnrollmentRepo<EnrollmentModel, int> repo;
        private ExceptionConfig exception = new ExceptionConfig();

        public EnrollmentUseCase(IEnrollmentRepo<EnrollmentModel, int> _repo)
        {
            repo = _repo;
        }

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

                throw exception.Error(ex, ErrorStatus.Delete.GetEnumDescription());
            }
        }

        public List<EnrollmentModel> GetAll()
        {
            try
            {
                return repo.GetAll();
            }
            catch (Exception ex)
            {

                throw exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription());
            }
        }

        public EnrollmentModel GetByID(int entityID)
        {
            try
            {
                return repo.GetByID(entityID);
            }
            catch (Exception ex)
            {

                throw exception.Error(ex, ErrorStatus.Retrieve.GetEnumDescription());
            }
        }

        public bool Insert(EnrollmentModel entity)
        {
            try
            {
                var result = repo.Insert(entity);
                repo.SaveAll();
                return result;
            }
            catch (Exception ex)
            {
                throw exception.Error(ex, ErrorStatus.Insert.GetEnumDescription());
            }
        }

    }
}
