using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionEstudiantesMaterias.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IBaseService<SubjectDto, int> db;

        public SubjectController(IBaseService<SubjectDto, int> _db)
        {
            db = _db;
        }

        public IActionResult vSubjectIni()
        {
            List<SubjectDto> entity = db.GetAll();
            return View(entity);
        }

        public IActionResult vSubjectDet(int Code)
        {

            SubjectDto studenDto = new SubjectDto();

            ViewBag.Accion = "New";

            if (Code != 0)
            {

                ViewBag.Accion = "Update";
                studenDto = db.GetByID(Code);

            }

            return View(studenDto);
        }

        [HttpPost]
        public IActionResult SaveChanges(SubjectDto entity)
        {
            bool response;
            if (entity.Code == 0)
            {
                response = db.Insert(entity);
            }
            else
            {
                response = db.Update(entity);
            }

            if (response)
                return RedirectToAction("vSubjectIni");
            else
                return NoContent();
        }

        [HttpGet]
        public IActionResult Delete(int Code)
        {

            var response = db.Delete(Code);

            if (response)
                return RedirectToAction("vSubjectIni");
            else
                return NoContent();
        }
    }
}
