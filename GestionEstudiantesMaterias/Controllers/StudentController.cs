using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionEstudiantesMaterias.Controllers
{
    public class StudentController : Controller 
    {
        private readonly IBaseService<StudentDto, string> db;

        public StudentController(IBaseService<StudentDto, string> _db)
        {
            db = _db;
        }

        public IActionResult vStudentIni()
        {
            List<StudentDto> entity = db.GetAll();
            return View(entity);
        }

        public IActionResult vStudentDet(string Document, int insert)
        {
            ViewData["Insert"] = insert;
            StudentDto studenDto = new StudentDto();

            ViewBag.Accion = "New";

            if (Document != null)
            {

                ViewBag.Accion = "Update";
                studenDto = db.GetByID(Document);

            }

            return View(studenDto);
        }

        [HttpPost]
        public IActionResult SaveChanges(StudentDto entity, int insert)
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

        [HttpGet]
        public IActionResult Delete(string Document)
        {

            var response = db.Delete(Document);

            if (response)
                return RedirectToAction("vStudentIni");
            else
                return NoContent();
        }

    }
}
