using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionEstudiantesMaterias.Controllers
{
    public class SubjectController : Controller
    {
        #region Attributes
        private readonly IBaseService<SubjectDto, int> db;
        #endregion

        #region Constructors
        public SubjectController(IBaseService<SubjectDto, int> _db)
        {
            db = _db;
        }
        #endregion

        #region Methods
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
            try
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
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("vSubjetDet", "Subject", new { Code = entity.Code });
            }

        }

        [HttpGet]
        public IActionResult Delete(int Code)
        {
            try
            {
                var response = db.Delete(Code);

                if (response)
                    return RedirectToAction("vSubjectIni");
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("vSubjectIni");
            }

        } 
        #endregion
    }
}
