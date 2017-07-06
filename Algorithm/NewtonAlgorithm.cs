using System;

namespace Algorithm
{
    /// <summary>
    /// Realization of the Newton algorithm
    /// </summary>
    public static class NewtonAlgorithm
    {
        private const double MinPrecision = 0.1;
        private static readonly double MaxPrecision = Math.Pow(10, -sizeof(double) * 8);

        /// <summary>
        /// Finds the nth root of the given number using the Newton algorithm
        /// </summary>
        /// <param name="number">Number to extract root from</param>
        /// <param name="n">Root degree</param>
        /// <param name="epsilon">Precision</param>
        /// <returns>The nth root of the given number</returns>
        public static double SqrtN(double number, double n, double epsilon = 0.0001)
        {
            CheckParameters(number, n, epsilon);

            double currentValue;
            double nextValue = number / n;
            do
            {
                currentValue = nextValue;
                nextValue = GetNextValue(currentValue, number, n);
            } while (Math.Abs(nextValue - currentValue) > epsilon);

            return nextValue;
        }

        /// <summary>
        /// Performs the next iteration of the Newton algorithm and returns its result
        /// </summary>
        /// <param name="currentValue">Approximation calculated at previous iterations</param>
        /// <param name="number">Number to extract root from</param>
        /// <param name="n">Root degree</param>
        /// <returns></returns>
        private static double GetNextValue(double currentValue, double number, double n)
        {
            return ((n -1) * currentValue + number / Math.Pow(currentValue, n - 1)) / n;
        }

        /// <summary>
        /// Checks if possible to find the nth root with the given parameters
        /// </summary>
        /// <param name="number">Number to extract root from</param>
        /// <param name="n">Root degree</param>
        /// <param name="epsilon">Precision</param>
        private static void CheckParameters(double number, double n, double epsilon)
        {
            if (n <= 0)
                throw new ArgumentException($"Root degree {nameof(n)} cannot be negative");

            if (epsilon > MinPrecision || epsilon < MaxPrecision)
                throw new ArgumentException($"Precision value {nameof(epsilon)} is out of range");

            if (number < 0 && n % 2 == 0)
                throw new ArgumentException(
                    $"Aliquot root {nameof(n)} cannot be taken from a negative number {nameof(number)}");
        }
    }
}