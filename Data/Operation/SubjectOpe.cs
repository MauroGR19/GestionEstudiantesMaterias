using AutoMapper;
using Data.Contex;
using Data.Entity;
using Domain.Interface.Repository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operation
{
    public class SubjectOpe : IRepoBase<SubjectModel, int>
    {
        private StudentSubjectContex db;
        private readonly IMapper _mapper;

        public SubjectOpe(StudentSubjectContex _db, IMapper mapper)
        {
            db = _db;
            _mapper = mapper;
        }

        public bool Delete(int entityID)
        {
            var selecc = db.subject.Where(row => row.Code == entityID).FirstOrDefault();

            if (selecc != null)
            {
                db.subject.Remove(selecc);
                return true;
            }
            else
                return false;
        }

        public List<SubjectModel> GetAll()
        {
            return _mapper.Map<List<SubjectModel>>(db.subject.ToList());
        }

        public SubjectModel GetByID(int entityID)
        {
            var selecc = db.subject.Where(row => (row.Code == entityID)).FirstOrDefault();

            return _mapper.Map<SubjectModel>(selecc);
        }

        public bool Insert(SubjectModel entity)
        {
            db.subject.Add(_mapper.Map<SubjectEntity>(entity));
            return true;
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }

        public bool Update(SubjectModel entity)
        {
            var selecc = db.subject.Where(row => row.Code == entity.Code).FirstOrDefault();

            if (selecc != null)
            {
                selecc.Name = entity.Name;
                selecc.Credits = entity.Credits;

                db.Entry(selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            else
                return false;
        }

    }
}
