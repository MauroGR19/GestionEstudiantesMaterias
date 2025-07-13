using AutoMapper;
using Data.Contex;
using Data.Entity;
using Domain.Interface.Repository;
using Domain.Model;

namespace Data.Operation
{
    public class EnrollmentOpe : IEnrollmentRepo<EnrollmentModel, int>
    {
        #region Attributes
        private StudentSubjectContex db;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public EnrollmentOpe(StudentSubjectContex _db, IMapper mapper)
        {
            db = _db;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public bool Delete(int entityID)
        {
            var selecc = db.enrollment.Where(row => row.IdEnrollment == entityID).FirstOrDefault();

            if (selecc != null)
            {
                db.enrollment.Remove(selecc);
                return true;
            }
            else
                return false;
        }

        public List<EnrollmentModel> GetAll(string Document)
        {
            return _mapper.Map<List<EnrollmentModel>>(db.enrollment.Where(row => (row.Document == Document)).ToList());
        }

        public EnrollmentModel GetByID(string Document, int Code)
        {
            var selecc = db.enrollment.Where(row => (row.Code == Code && row.Document == Document)).FirstOrDefault();

            return _mapper.Map<EnrollmentModel>(selecc);
        }

        public bool Insert(EnrollmentModel entity)
        {
            db.enrollment.Add(_mapper.Map<EnrollmentEntity>(entity));
            return true;
        }

        public void SaveAll()
        {
            db.SaveChanges();
        } 
        #endregion

    }
}
