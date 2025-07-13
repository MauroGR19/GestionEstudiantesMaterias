using GestionEstudiantesMaterias.Controllers;
using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Test;

public class StudentControllerTest
{
    #region Attributes
    private Mock<IBaseService<StudentDto, string>> _studentServiceMock;
    private Mock<IEnrollmentService<EnrollmentDto, int>> _enrollmentServiceMock;
    private Mock<IBaseService<SubjectDto, int>> _subjectServiceMock;
    private StudentController _controller;
    #endregion

    #region Constructors
    [SetUp]
    public void Setup()
    {
        _studentServiceMock = new Mock<IBaseService<StudentDto, string>>();
        _enrollmentServiceMock = new Mock<IEnrollmentService<EnrollmentDto, int>>();
        _subjectServiceMock = new Mock<IBaseService<SubjectDto, int>>();

        _controller = new StudentController(
            _studentServiceMock.Object,
            _enrollmentServiceMock.Object,
            _subjectServiceMock.Object
        );
    }
    #endregion

    #region Methods
    [Test]
    public void vStudentIni_ReturnsViewWithStudents()
    {
        // Arrange
        var students = new List<StudentDto> { new StudentDto { Document = "123", Name = "Test" } };
        _studentServiceMock.Setup(s => s.GetAll()).Returns(students);

        // Act
        var result = _controller.vStudentIni();

        // Assert
        var viewResult = result as ViewResult;
        Assert.IsNotNull(viewResult);
        Assert.IsInstanceOf<List<StudentDto>>(viewResult.Model);
        Assert.AreEqual(students, viewResult.Model);
    }

    [Test]
    public void vStudentDet_WithDocument_ReturnsStudentWithEnrollments()
    {
        // Arrange
        var document = "123";
        var student = new StudentDto
        {
            Document = document,
            Enrollments = new List<EnrollmentDto> { new EnrollmentDto { Code = 1 } }
        };

        var subject = new SubjectDto { Code = 1, Name = "Math" };

        _studentServiceMock.Setup(s => s.GetByID(document)).Returns(student);
        _enrollmentServiceMock.Setup(e => e.GetAll(document)).Returns(student.Enrollments);
        _subjectServiceMock.Setup(s => s.GetByID(1)).Returns(subject);

        // Act
        var result = _controller.vStudentDet(document, 1);

        // Assert
        var viewResult = result as ViewResult;
        Assert.IsNotNull(viewResult);
        var model = viewResult.Model as StudentDto;
        Assert.IsNotNull(model);
        Assert.AreEqual(document, model.Document);
        Assert.AreEqual("Math", model.Enrollments[0].Subject.Name);
    }

    [Test]
    public void SaveChanges_InsertSuccess_RedirectsToIni()
    {
        // Arrange
        var student = new StudentDto { Document = "123" };
        _studentServiceMock.Setup(s => s.Insert(student)).Returns(true);

        // Act
        var result = _controller.SaveChanges(student, 0);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = result as RedirectToActionResult;
        Assert.AreEqual("vStudentIni", redirect.ActionName);
    }

    [Test]
    public void SaveChanges_UpdateSuccess_RedirectsToIni()
    {
        // Arrange
        var student = new StudentDto { Document = "123" };
        _studentServiceMock.Setup(s => s.Update(student)).Returns(true);

        // Act
        var result = _controller.SaveChanges(student, 1);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = result as RedirectToActionResult;
        Assert.AreEqual("vStudentIni", redirect.ActionName);
    }


    [Test]
    public void Delete_Success_RedirectsToIni()
    {
        // Arrange
        var document = "123";
        _studentServiceMock.Setup(s => s.Delete(document)).Returns(true);

        // Act
        var result = _controller.Delete(document);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirect = result as RedirectToActionResult;
        Assert.AreEqual("vStudentIni", redirect.ActionName);
    }
    #endregion

}
