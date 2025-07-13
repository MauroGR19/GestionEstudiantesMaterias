using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Editing;

namespace GestionEstudiantesMaterias.Controllers
{
    public class StudentController : Controller 
    {
        #region Attributes
        private readonly IBaseService<StudentDto, string> db;
        private readonly IEnrollmentService<EnrollmentDto, int> enrollment;
        private readonly IBaseService<SubjectDto, int> subject;
        #endregion

        #region Constructors
        public StudentController(IBaseService<StudentDto, string> _db, IEnrollmentService<EnrollmentDto, int> _enrollment, IBaseService<SubjectDto, int> _subject)
        {
            db = _db;
            enrollment = _enrollment;
            subject = _subject;
        }
        #endregion

        #region Methods
        public IActionResult vStudentIni()
        {
            List<StudentDto> entity = db.GetAll();
            return View(entity);
        }

        public IActionResult vStudentDet(string Document, int insert)
        {
            ViewData["Insert"] = insert;
            StudentDto studentDto = new StudentDto();

            ViewBag.Accion = "New";
            if (TempData["Clear"] == "Clear")
            {
                Document = null;
            }
            if (Document != null)
            {
                ViewBag.Accion = "Update";
                studentDto = db.GetByID(Document);
                studentDto.Enrollments = enrollment.GetAll(Document);
                foreach (var enrollment in studentDto.Enrollments)
                    enrollment.Subject = subject.GetByID(enrollment.Code);
            }

            return View(studentDto);
        }

        [HttpPost]
        public IActionResult SaveChanges(StudentDto entity, int insert)
        {
            try
            {
                bool response;
                if (insert == 0)
                {
                    response = db.Insert(entity);
                }
                else
                {
                    response = db.Update(entity);
                }

                if (response)
                    return RedirectToAction("vStudentIni");
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                TempData["Clear"] = "Clear"; 
                return RedirectToAction("vStudentDet", "Student", new { Document = entity.Document, insert = insert });
            }
        }

        [HttpGet]
        public IActionResult Delete(string Document)
        {
            try
            {
                var response = db.Delete(Document);

                if (response)
                    return RedirectToAction("vStudentIni");
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("vStudentIni");
            }
        } 
        #endregion

    }
}
