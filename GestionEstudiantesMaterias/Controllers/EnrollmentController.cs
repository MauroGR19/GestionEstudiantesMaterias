using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionEstudiantesMaterias.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService<EnrollmentDto, int> db;
        private readonly IBaseService<SubjectDto, int> db_Subjects;

        public EnrollmentController(IEnrollmentService<EnrollmentDto, int> _db, IBaseService<SubjectDto, int> _db_Subjects)
        {
            db = _db;
            db_Subjects = _db_Subjects;
        }

        public IActionResult vEnrollmentDet()
        {
            EnrollmentDto enrollment = new EnrollmentDto();
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
            bool response;
            response = db.Insert(entity);
            if (response)
                return RedirectToAction("vEnrollmentIni");
            else
                return NoContent();
        }

        [HttpPost]
        public IActionResult Delete(int Code)
        {
            var response = db.Delete(Code);
            if (response)
                return RedirectToAction("vEnrollmentIni");
            else
                return NoContent();
        }
    }
}
