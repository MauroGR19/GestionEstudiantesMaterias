using GestionEstudiantesMaterias.Controllers;
using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;

namespace Test
{
    public class EnrollmentControllerTest
    {
        #region Attributes
        private Mock<IEnrollmentService<EnrollmentDto, int>> _enrollmentServiceMock;
        private Mock<IBaseService<SubjectDto, int>> _subjectServiceMock;
        private EnrollmentController _controller;
        #endregion

        #region Constructors
        [SetUp]
        public void Setup()
        {
            _enrollmentServiceMock = new Mock<IEnrollmentService<EnrollmentDto, int>>();
            _subjectServiceMock = new Mock<IBaseService<SubjectDto, int>>();
            _controller = new EnrollmentController(_enrollmentServiceMock.Object, _subjectServiceMock.Object);
        }
        #endregion

        #region Methods
        [Test]
        public void vEnrollmentDet_ReturnsViewWithSubjectsAndEnrollment()
        {
            // Arrange
            var document = "123";
            var subjects = new List<SubjectDto> { new SubjectDto { Code = 1, Name = "Math" } };
            _subjectServiceMock.Setup(s => s.GetAll()).Returns(subjects);

            // Act
            var result = _controller.vEnrollmentDet(document) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as EnrollmentDto;
            Assert.AreEqual(document, model.Document);
            Assert.AreEqual("New", _controller.ViewBag.Accion);
            Assert.IsInstanceOf<SelectList>(result.ViewData["Subjects"]);
            Assert.AreEqual(subjects, result.ViewData["Subjects1"]);
        }

        [Test]
        public void SaveChanges_SuccessfulInsert_RedirectsToStudentDet()
        {
            // Arrange
            var entity = new EnrollmentDto { Document = "123" };
            _enrollmentServiceMock.Setup(s => s.Insert(entity)).Returns(true);

            // Act
            var result = _controller.SaveChanges(entity) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("vStudentDet", result.ActionName);
            Assert.AreEqual("Student", result.ControllerName);
            Assert.AreEqual("123", result.RouteValues["Document"]);
        }

        [Test]
        public void SaveChanges_InsertFails_ReturnsNoContent()
        {
            // Arrange
            var entity = new EnrollmentDto { Document = "123" };
            _enrollmentServiceMock.Setup(s => s.Insert(entity)).Returns(false);

            // Act
            var result = _controller.SaveChanges(entity);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void Delete_Successful_RedirectsToStudentDet()
        {
            // Arrange
            int id = 1;
            string document = "123";
            _enrollmentServiceMock.Setup(s => s.Delete(id)).Returns(true);

            // Act
            var result = _controller.Delete(id, document) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("vStudentDet", result.ActionName);
            Assert.AreEqual("Student", result.ControllerName);
        } 
        #endregion

    }
}