using GestionEstudiantesMaterias.Controllers;
using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Test;

public class SubjectControllerTest
{
    #region Attributes
    private Mock<IBaseService<SubjectDto, int>> _serviceMock;
    private SubjectController _controller;
    #endregion

    #region Constructors
    [SetUp]
    public void Setup()
    {
        _serviceMock = new Mock<IBaseService<SubjectDto, int>>();
        _controller = new SubjectController(_serviceMock.Object);
    }
    #endregion

    #region Methods
    [Test]
    public void vSubjectIni_ReturnsViewWithSubjects()
    {
        // Arrange
        var subjects = new List<SubjectDto> { new SubjectDto { Code = 1, Name = "Math" } };
        _serviceMock.Setup(s => s.GetAll()).Returns(subjects);

        // Act
        var result = _controller.vSubjectIni();

        // Assert
        var viewResult = result as ViewResult;
        Assert.IsNotNull(viewResult);
        Assert.IsInstanceOf<List<SubjectDto>>(viewResult.Model);
        Assert.AreEqual(subjects, viewResult.Model);
    }

    [Test]
    public void vSubjectDet_WithCode_ReturnsSubjectForEdit()
    {
        // Arrange
        var code = 1;
        var subject = new SubjectDto { Code = code, Name = "Science" };
        _serviceMock.Setup(s => s.GetByID(code)).Returns(subject);

        // Act
        var result = _controller.vSubjectDet(code);

        // Assert
        var viewResult = result as ViewResult;
        Assert.IsNotNull(viewResult);
        var model = viewResult.Model as SubjectDto;
        Assert.IsNotNull(model);
        Assert.AreEqual(code, model.Code);
    }

    [Test]
    public void vSubjectDet_WithZeroCode_ReturnsNewSubject()
    {
        // Act
        var result = _controller.vSubjectDet(0);

        // Assert
        var viewResult = result as ViewResult;
        Assert.IsNotNull(viewResult);
        var model = viewResult.Model as SubjectDto;
        Assert.IsNotNull(model);
        Assert.AreEqual(0, model.Code);
    }

    [Test]
    public void SaveChanges_InsertSuccess_RedirectsToIni()
    {
        // Arrange
        var subject = new SubjectDto { Code = 0, Name = "New Subject" };
        _serviceMock.Setup(s => s.Insert(subject)).Returns(true);

        // Act
        var result = _controller.SaveChanges(subject);

        // Assert
        var redirect = result as RedirectToActionResult;
        Assert.IsNotNull(redirect);
        Assert.AreEqual("vSubjectIni", redirect.ActionName);
    }

    [Test]
    public void SaveChanges_UpdateSuccess_RedirectsToIni()
    {
        // Arrange
        var subject = new SubjectDto { Code = 1, Name = "Updated Subject" };
        _serviceMock.Setup(s => s.Update(subject)).Returns(true);

        // Act
        var result = _controller.SaveChanges(subject);

        // Assert
        var redirect = result as RedirectToActionResult;
        Assert.IsNotNull(redirect);
        Assert.AreEqual("vSubjectIni", redirect.ActionName);
    }


    [Test]
    public void Delete_Success_RedirectsToIni()
    {
        // Arrange
        var code = 1;
        _serviceMock.Setup(s => s.Delete(code)).Returns(true);

        // Act
        var result = _controller.Delete(code);

        // Assert
        var redirect = result as RedirectToActionResult;
        Assert.IsNotNull(redirect);
        Assert.AreEqual("vSubjectIni", redirect.ActionName);
    } 
    #endregion

}
