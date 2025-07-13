using Aplication.UseCase;
using Domain.Interface.Repository;
using Domain.Model;
using Moq;

namespace Test
{
    public class StudentUseCaseTest
    {
        #region Attributes
        private Mock<IRepoBase<StudentModel, string>> _repoMock;
        private StudentUseCase _useCase;
        #endregion

        #region Constructors
        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IRepoBase<StudentModel, string>>();
            _useCase = new StudentUseCase(_repoMock.Object);
        }
        #endregion

        #region Methods
        [Test]
        public void Insert_ValidStudent_ReturnsTrue()
        {
            var student = new StudentModel { Document = "123", Name = "John", Email = "john@example.com" };
            _repoMock.Setup(r => r.Insert(student)).Returns(true);
            _repoMock.Setup(r => r.SaveAll());

            var result = _useCase.Insert(student);

            Assert.IsTrue(result);
            _repoMock.Verify(r => r.Insert(student), Times.Once);
            _repoMock.Verify(r => r.SaveAll(), Times.Once);
        }

        [Test]
        public void Update_ValidStudent_ReturnsTrue()
        {
            var student = new StudentModel { Document = "123", Name = "John Updated", Email = "john@update.com" };
            _repoMock.Setup(r => r.Update(student)).Returns(true);
            _repoMock.Setup(r => r.SaveAll());

            var result = _useCase.Update(student);

            Assert.IsTrue(result);
            _repoMock.Verify(r => r.Update(student), Times.Once);
            _repoMock.Verify(r => r.SaveAll(), Times.Once);
        }

        [Test]
        public void Delete_ExistingStudent_ReturnsTrue()
        {
            _repoMock.Setup(r => r.Delete("123")).Returns(true);
            _repoMock.Setup(r => r.SaveAll());

            var result = _useCase.Delete("123");

            Assert.IsTrue(result);
            _repoMock.Verify(r => r.Delete("123"), Times.Once);
            _repoMock.Verify(r => r.SaveAll(), Times.Once);
        }

        [Test]
        public void GetAll_ReturnsListOfStudents()
        {
            var students = new List<StudentModel> { new StudentModel { Document = "123", Name = "John" } };
            _repoMock.Setup(r => r.GetAll()).Returns(students);

            var result = _useCase.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetByID_ValidId_ReturnsStudent()
        {
            var student = new StudentModel { Document = "123", Name = "John" };
            _repoMock.Setup(r => r.GetByID("123")).Returns(student);

            var result = _useCase.GetByID("123");

            Assert.IsNotNull(result);
            Assert.AreEqual("123", result.Document);
        } 
        #endregion
    }
}