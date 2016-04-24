using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TccApp
{
	public partial class MatrixMultiply : ContentPage
	{

		private const string TAG = "MatrixMultiply";

		private const int NUMBER_OF_TESTS = 50;

		private int[,] randomMatrixA, randomMatrixB;

		public MatrixMultiply ()
		{
			InitializeComponent ();

			InitialLoad ();

		}

		private void InitialLoad() {

			btnCalculate.Clicked += BtnCalculate_Clicked;

		}

		void BtnCalculate_Clicked (object sender, EventArgs e) {


			FillRandomMatrix (Convert.ToInt32 (entMatrixSize.Text));
			MultiplyMatrixes ();
			
		}

		private void MultiplyMatrixes() {

			double averageTime = 0;
			double shortestTime = Double.MaxValue;
			double largestTime = Double.MinValue;
			double totalTime = 0;

			int[,] resultMatrix = new int[randomMatrixA.GetLength (0), randomMatrixB.GetLength (1)];

			for (int q = 0; q < NUMBER_OF_TESTS; q++) {

				DateTime startTime = DateTime.Now;

				for (int i = 0; i < randomMatrixA.GetLength (0); i++) {
					for (int j = 0; j < randomMatrixB.GetLength (1); j++) {

						for (int k = 0; k < randomMatrixB.GetLength (0); k++) {
							resultMatrix [i, j] += randomMatrixA [i, k] * randomMatrixB [i, j]; 
						}
					}
				}

				DateTime endTime = DateTime.Now;
				TimeSpan diffTime = endTime - startTime;

				if (diffTime.TotalMilliseconds < shortestTime) {
					shortestTime = diffTime.TotalMilliseconds;
				}

				if (diffTime.TotalMilliseconds > largestTime) {
					largestTime = diffTime.TotalMilliseconds;
				}

				totalTime += diffTime.TotalMilliseconds;

			}

			averageTime = totalTime / NUMBER_OF_TESTS;

			double averageTimeInSeconds = averageTime / 1000;
			double shortestTimeInSeconds = shortestTime / 1000;
			double largestTimeInSeconds = largestTime / 1000;
			double totalTimeInSeconds = totalTime / 1000;

			ShowResults (averageTimeInSeconds, shortestTimeInSeconds, largestTimeInSeconds, totalTimeInSeconds);

		}

		private void FillRandomMatrix(int size) {
			randomMatrixA = new int[size, size];
			randomMatrixB = new int[size, size];
			double randomNumber;
			for (int i = 0; i < size; i++) {
				for (int j = 0; j < size; j++) {
					randomNumber = new Random ().NextDouble ();
					randomMatrixA [i, j] = (int)(randomNumber * 100);
					randomNumber = new Random ().NextDouble ();
					randomMatrixB [i, j] = (int)(randomNumber * 100);
				}
			}
		}

		private void ShowResults(double averageTimeInSeconds, double shortestTimeInSeconds, double largestTimeInSeconds,
			double totalTimeInSeconds) {

			lblAverageTime.Text = "Tempo médio: " + averageTimeInSeconds.ToString () + " segundos.";
			lblShortestTime.Text = "Menor tempo: " + shortestTimeInSeconds.ToString () + " segundos.";
			lblLargestTime.Text = "Maior tempo: " + largestTimeInSeconds.ToString () + " segundos.";
			lblTotalTime.Text = "Tempo total: " + totalTimeInSeconds.ToString () + " segundos.";
			
		}

	}
}

