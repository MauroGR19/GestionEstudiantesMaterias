﻿using AutoMapper;
using Data.Contex;
using Data.Entity;
using Domain.Interface.Repository;
using Domain.Model;

namespace Data.Operation
{
    public class StudentOpe : IRepoBase<StudentModel, string>
    {
        #region Attributes
        private StudentSubjectContex db;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public StudentOpe(StudentSubjectContex _db, IMapper mapper)
        {
            db = _db;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public bool Delete(string entityID)
        {
            var selecc = db.student.Where(row => row.Document == entityID).FirstOrDefault();

            if (selecc != null)
            {
                db.student.Remove(selecc);
                return true;
            }
            else
                return false;
        }

        public List<StudentModel> GetAll()
        {
            return _mapper.Map<List<StudentModel>>(db.student.ToList());
        }

        public StudentModel GetByID(string entityID)
        {
            var selecc = db.student.Where(row => (row.Document == entityID)).FirstOrDefault();

            return _mapper.Map<StudentModel>(selecc);
        }

        public bool Insert(StudentModel entity)
        {
            db.student.Add(_mapper.Map<StudentEntity>(entity));
            return true;
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }

        public bool Update(StudentModel entity)
        {
            var selecc = db.student.Where(row => row.Document == entity.Document).FirstOrDefault();

            if (selecc != null)
            {
                selecc.Name = entity.Name;
                selecc.Email = entity.Email;

                db.Entry(selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            else
                return false;
        } 
        #endregion

    }

}
