using Calculator;
using NUnit.Framework.Interfaces;

namespace Calculator.Test.Unit
{
    public class Tests
    {
        private CalculatorClass uut;
        [SetUp]
        public void Setup()
        {
            uut = new CalculatorClass();
        }

        [Test]
        public void TestAddTwoDoubleNumbers()
        {
            var x = uut.Add(1, 2);
            Assert.That(x, Is.EqualTo(3));
        }

        [TestCase(-2, 3, ExpectedResult = 1)]

        [TestCase(2,3, ExpectedResult = 5) ]
        public double MultipleTestsAddTwoDoubleNumbers(double param1, double param2)
        {
            var x = uut.Add(param1, param2);
            return x;
        }
    }
}