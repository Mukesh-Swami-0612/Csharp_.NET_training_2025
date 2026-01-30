using NUnit.Framework;
using Moq;
using CollegeService;

namespace CollegeService.Tests
{
    [TestFixture]
    public class CollegeServiceTest
    {
        private Mock<ICollegeService> _mockService;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<ICollegeService>();
        }

        [Test]
        public void TestWelcomeNote_UsingMock()
        {
            // Arrange
            _mockService
                .Setup(x => x.GetWelcomeNote("John"))
                .Returns("Welcome, John");

            // Act
            var result = _mockService.Object.GetWelcomeNote("John");

            // Assert (NEW NUnit style)
            Assert.That(result, Is.EqualTo("Welcome, John"));
        }

        [Test]
        public void TestFarewellNote_UsingRealClass()
        {
            // Arrange
            ICollegeService service = new CollegeService();

            // Act
            var result = service.GetFarewellNote("John");

            // Assert (NEW NUnit style)
            Assert.That(result, Is.EqualTo("All the best, John"));
        }
    }
}

//tierdown