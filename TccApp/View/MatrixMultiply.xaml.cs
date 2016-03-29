using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TccApp
{
	public partial class MatrixMultiply : ContentPage
	{

		private const string TAG = "MatrixMultiply";

		private int[,] randomMatrixA, randomMatrixB;

		public MatrixMultiply ()
		{
			InitializeComponent ();
		}

		private void InitialLoad() {
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

	}
}

