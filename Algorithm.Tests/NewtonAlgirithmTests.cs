using System;
using NUnit.Framework;

namespace Algorithm.Tests
{
    [TestFixture]
    public class NewtonAlgorithmTests
    {
        [TestCase(16, 4, 0.00001)]
        [TestCase(10.345, 26, 1E-16)]
        [TestCase(-9, 3, 0.001)]
        [TestCase(-634517, 5, 0.00001)]
        [TestCase(-45.5, 11, 1E-10)]
        public void SqrtN_ValidInputParameters_NthRootWithPercisionReturned(double number, double n, double epsilon)
        {
            double calculatedValue = NewtonAlgorithm.SqrtN(number, n, epsilon);
            double exactValue = Math.Pow(number, 1.0 / n);

            Assert.Less(Math.Abs(exactValue - calculatedValue), epsilon);
        }

        [TestCase(15, -4, 0.0001)]
        [TestCase(15.7, 0, 0.0001)]
        [TestCase(-19, 8, 0.00001)]
        [TestCase(15, 7, -0.001)]
        [TestCase(9.2, 3, 1E-600)]
        public void SqrtN_InvalidParameters_NthRootCannotBeTaken(double number, double n, double epsilon)
        {
            Assert.Throws<ArgumentException>(() => NewtonAlgorithm.SqrtN(number, n, epsilon));
        }
    }
}
