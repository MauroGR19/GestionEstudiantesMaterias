using AutoMapper;
using Data.Contex;
using Data.Entity;
using Domain.Interface.Repository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operation
{
    public class EnrollmentOpe : IEnrollmentRepo<EnrollmentModel, int>
    {
        private StudentSubjectContex db;
        private readonly IMapper _mapper;

        public EnrollmentOpe(StudentSubjectContex _db, IMapper mapper)
        {
            db = _db;
            _mapper = mapper;
        }

        public bool Delete(int entityID)
        {
            var selecc = db.enrollment.Where(row => row.Code == entityID).FirstOrDefault();

            if (selecc != null)
            {
                db.enrollment.Remove(selecc);
                return true;
            }
            else 
                return false;
        }

        public List<EnrollmentModel> GetAll()
        {
            return _mapper.Map<List<EnrollmentModel>>(db.enrollment.ToList());
        }

        public EnrollmentModel GetByID(int entityID)
        {
            var selecc = db.enrollment.Where(row => (row.Code == entityID)).FirstOrDefault();

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

    }
}
