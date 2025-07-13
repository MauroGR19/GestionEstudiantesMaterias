using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionEstudiantesMaterias.Controllers
{
    public class EnrollmentController : Controller
    {
        #region Attributes
        private readonly IEnrollmentService<EnrollmentDto, int> db;
        private readonly IBaseService<SubjectDto, int> db_Subjects;
        #endregion

        #region Constructors
        public EnrollmentController(IEnrollmentService<EnrollmentDto, int> _db, IBaseService<SubjectDto, int> _db_Subjects)
        {
            db = _db;
            db_Subjects = _db_Subjects;
        }
        #endregion

        #region Methods
        public IActionResult vEnrollmentDet(string Document)
        {
            EnrollmentDto enrollment = new EnrollmentDto();
            enrollment.Document = Document;
            ViewBag.Accion = "New";
            var data = db_Subjects.GetAll();
            var objet = new SelectList(data, "Code", "Name");
            ViewData["Subjects"] = objet;
            ViewData["Subjects1"] = data;
            return View(enrollment);
        }

        [HttpPost]
        public IActionResult SaveChanges(EnrollmentDto entity)
        {
            try
            {
                bool response;
                response = db.Insert(entity);
                if (response)
                    return RedirectToAction("vStudentDet", "Student", new { Document = entity.Document, insert = 1 });
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("vEnrollmentDet", "Enrollment", new { Document = entity.Document });
            }
        }

        [HttpGet]
        public IActionResult Delete(int IdEnrollment, string Document)
        {
            try
            {
                var response = db.Delete(IdEnrollment);
                if (response)
                    return RedirectToAction("vStudentDet", "Student", new { Document = Document, insert = 1 });
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("vStudentDet", "Student", new { Document = Document, insert = 1 });
            }
        } 
        #endregion
    }
}
