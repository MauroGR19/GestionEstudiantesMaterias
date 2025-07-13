using Aplication.UseCase;
using Domain.Interface.Repository;
using Domain.Model;
using Moq;

namespace Test
{
    public class SubjecUseCaseTest
    {
        #region Attributes
        private Mock<IRepoBase<SubjectModel, int>> _repoMock;
        private SubjectUseCase _useCase;
        #endregion

        #region Constructors
        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IRepoBase<SubjectModel, int>>();
            _useCase = new SubjectUseCase(_repoMock.Object);
        }
        #endregion

        #region Methods
        [Test]
        public void Insert_ValidSubject_ReturnsTrue()
        {
            var subject = new SubjectModel { Code = 1, Name = "Math", Credits = 3 };
            _repoMock.Setup(r => r.Insert(subject)).Returns(true);
            _repoMock.Setup(r => r.SaveAll());

            var result = _useCase.Insert(subject);

            Assert.IsTrue(result);
            _repoMock.Verify(r => r.Insert(subject), Times.Once);
            _repoMock.Verify(r => r.SaveAll(), Times.Once);
        }

        [Test]
        public void Update_ValidSubject_ReturnsTrue()
        {
            var subject = new SubjectModel { Code = 1, Name = "Math Updated", Credits = 4 };
            _repoMock.Setup(r => r.Update(subject)).Returns(true);
            _repoMock.Setup(r => r.SaveAll());

            var result = _useCase.Update(subject);

            Assert.IsTrue(result);
            _repoMock.Verify(r => r.Update(subject), Times.Once);
            _repoMock.Verify(r => r.SaveAll(), Times.Once);
        }

        [Test]
        public void Delete_ExistingSubject_ReturnsTrue()
        {
            _repoMock.Setup(r => r.Delete(1)).Returns(true);
            _repoMock.Setup(r => r.SaveAll());

            var result = _useCase.Delete(1);

            Assert.IsTrue(result);
            _repoMock.Verify(r => r.Delete(1), Times.Once);
            _repoMock.Verify(r => r.SaveAll(), Times.Once);
        }

        [Test]
        public void GetAll_ReturnsListOfSubjects()
        {
            var subjects = new List<SubjectModel> { new SubjectModel { Code = 1, Name = "Math" } };
            _repoMock.Setup(r => r.GetAll()).Returns(subjects);

            var result = _useCase.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetByID_ValidId_ReturnsSubject()
        {
            var subject = new SubjectModel { Code = 1, Name = "Math" };
            _repoMock.Setup(r => r.GetByID(1)).Returns(subject);

            var result = _useCase.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Code);
        } 
        #endregion
    }
}
