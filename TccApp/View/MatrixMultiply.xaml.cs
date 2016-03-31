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
		}

		private void InitialLoad() {

			btnCalculate.Clicked += BtnCalculate_Clicked;

		}

		void BtnCalculate_Clicked (object sender, EventArgs e) {
			double averageTime, shortestTime, largestTime, totalTime;

			for (int q = 0; q < NUMBER_OF_TESTS; q++) {
			}

			showResults (averageTime, shortestTime, largestTime, totalTime);
			
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

		private void showResults(double averageTimeInSeconds, double shortestTimeInSeconds, double largestTimeInSeconds,
			double totalTimeInSeconds) {
			
		}

	}
}

