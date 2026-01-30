using NUnit.Framework;
using MyLibrary;

namespace MyLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private ICalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ReturnsCorrectSum()
        {
            Assert.That(_calculator.Add(10, 20), Is.EqualTo(30));
        }

        [Test]
        public void Divide_ReturnsCorrectResult()
        {
            Assert.That(_calculator.Divide(10, 2), Is.EqualTo(5));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(
                () => _calculator.Divide(10, 0)
            );
        }
    }
}

