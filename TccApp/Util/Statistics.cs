using System;

namespace TccApp
{
	public static class Statistics
	{

		/// <summary>
		/// Gets the standard deviation of a set of values.
		/// </summary>
		/// <returns>The standard deviation.</returns>
		/// <param name="arr">Array of long value.</param>
		public static double GetStandardDeviation(long[] arr) {
			return Math.Sqrt(GetVariance(arr));
		}

		/// <summary>
		/// Gets the variance of a set of values.
		/// </summary>
		/// <returns>The variance.</returns>
		/// <param name="arr">Array of long values.</param>
		public static double GetVariance(long[] arr) {
			double avg = GetAverage(arr);
			double sum = 0;
			foreach (long value in arr) {
				sum += Math.Pow ((value - avg), 2);
			}
			return sum / arr.Length;
		}

		/// <summary>
		/// Gets the average of a set of values.
		/// </summary>
		/// <returns>The variance.</returns>
		/// <param name="arr">Array of long values.</param>
		public static double GetAverage(long[] arr) {
			long sum = 0;
			foreach(long value in arr) {
				sum += value;
			}
			return sum / arr.Length;
		}

	}
}

