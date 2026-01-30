using CalculatorApp.Core;
using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [Test]
    public void Add_ReturnsCorrectSum()
    {
        int result = calculator.Add(5, 3);
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Subtract_ReturnsCorrectDifference()
    {
        int result = calculator.Subtract(10, 4);
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Multiply_ReturnsCorrectProduct()
    {
        int result = calculator.Multiply(3, 4);
        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void Divide_ReturnsCorrectQuotient()
    {
        int result = calculator.Divide(20, 5);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.That(() => calculator.Divide(10, 0),
            Throws.TypeOf<DivideByZeroException>());
    }
}
