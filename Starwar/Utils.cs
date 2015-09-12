namespace Starwar
{
    using System;

    internal static class Utils
    {
        private static readonly Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Gets a random number between <paramref name="minValue"/> and <paramref name="maxValue"/> (inclusive).
        /// </summary>
        /// <param name="minValue">The minimal value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>A random number between <paramref name="minValue"/> and <paramref name="maxValue"/> (inclusive).</returns>
        internal static float GetRandomNumber(float minValue, float maxValue)
        {
            return Convert.ToSingle(random.NextDouble()*(maxValue - minValue)) + minValue;
        }
    }
}
