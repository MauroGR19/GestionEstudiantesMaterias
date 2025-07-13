using Aplication.Interface;
using Aplication.UseCase;
using Domain.Interface.Repository;
using Domain.Model;
using Moq;

namespace Test
{
    public class EnrollmentUseCaseTest
    {
        #region Attributes
        private Mock<IEnrollmentRepo<EnrollmentModel, int>> _repoMock;
        private Mock<IUseCaseBase<SubjectModel, int>> _subjectsMock;
        private EnrollmentUseCase _useCase;
        #endregion

        #region Constructors
        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IEnrollmentRepo<EnrollmentModel, int>>();
            _subjectsMock = new Mock<IUseCaseBase<SubjectModel, int>>();
            _useCase = new EnrollmentUseCase(_repoMock.Object, _subjectsMock.Object);
        }
        #endregion

        #region Methods
        [Test]
        public void Delete_ValidId_ReturnsTrue()
        {
            _repoMock.Setup(r => r.Delete(It.IsAny<int>())).Returns(true);
            _repoMock.Setup(r => r.SaveAll());

            var result = _useCase.Delete(1);

            Assert.IsTrue(result);
            _repoMock.Verify(r => r.SaveAll(), Times.Once);
        }

        [Test]
        public void GetAll_WithValidDocument_ReturnsEnrollments()
        {
            var list = new List<EnrollmentModel> { new EnrollmentModel() };
            _repoMock.Setup(r => r.GetAll(It.IsAny<string>())).Returns(list);

            var result = _useCase.GetAll("123");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetByID_ValidInputs_ReturnsEnrollment()
        {
            var enrollment = new EnrollmentModel { Document = "123", Code = 1 };
            _repoMock.Setup(r => r.GetByID("123", 1)).Returns(enrollment);

            var result = _useCase.GetByID("123", 1);

            Assert.IsNotNull(result);
            Assert.AreEqual("123", result.Document);
        }

        [Test]
        public void Insert_ValidEnrollment_ReturnsTrue()
        {
            var entity = new EnrollmentModel { Document = "123", Code = 1 };

            _repoMock.Setup(r => r.GetByID(entity.Document, entity.Code)).Returns((EnrollmentModel)null);
            _repoMock.Setup(r => r.GetAll(entity.Document)).Returns(new List<EnrollmentModel>());
            _subjectsMock.Setup(s => s.GetByID(entity.Code)).Returns(new SubjectModel { Credits = 3 });
            _repoMock.Setup(r => r.Insert(entity)).Returns(true);
            _repoMock.Setup(r => r.SaveAll());

            var result = _useCase.Insert(entity);

            Assert.IsTrue(result);
            _repoMock.Verify(r => r.Insert(entity), Times.Once);
            _repoMock.Verify(r => r.SaveAll(), Times.Once);
        } 
        #endregion

    }
}

