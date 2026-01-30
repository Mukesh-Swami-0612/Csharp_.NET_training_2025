using NUnit.Framework;
using MyLibrary;
using System.Collections.Generic;

namespace MyLibrary.Tests;

create a two methods using Interface and implement into class

[TestFixture]
public class CalculatorTests
{
    private Calculator _calc;

    [SetUp]
    public void Setup()
    {
        _calc = new Calculator();
    }

    [Test]
    public void All_Assertion_Examples()
    {
        // Equality
        Assert.That(_calc.Add(2, 2), Is.EqualTo(4));
        Assert.That(_calc.Add(2, 2), Is.Not.EqualTo(5));

        // String assertions
        string msg = _calc.GetGreeting("Alice");
        Assert.That(msg, Does.Contain("Alice"));
        Assert.That(msg, Does.StartWith("Hello"));
        Assert.That(msg, Is.Not.Empty);

        // Numeric & range
        Assert.That(_calc.Divide(10, 3), Is.EqualTo(3.33).Within(0.01));
        int sum = _calc.Add(5, 5);
        Assert.That(sum, Is.GreaterThan(5));
        Assert.That(sum, Is.InRange(1, 100));

        // Boolean
        bool isCorrect = _calc.Add(1, 1) == 2;
        Assert.That(isCorrect, Is.True);

        // Null
        object? value = null;
        Assert.That(value, Is.Null);

        // Collection
        var list = new List<int> { 1, 2, 3 };
        Assert.That(list, Has.Exactly(3).Items);
        Assert.That(list, Contains.Item(2));
        Assert.That(list, Is.Unique);

        // Exception
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
    }

    [TestCase(1, 2, 3)]
    [TestCase(-1, 1, 0)]
    [TestCase(100, 200, 300)]
    public void Add_MultipleInputs_ReturnsExpected(int a, int b, int expected)
    {
        Assert.That(_calc.Add(a, b), Is.EqualTo(expected));
    }
}
