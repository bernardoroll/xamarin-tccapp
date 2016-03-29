using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TccApp
{
	public partial class Main : ContentPage
	{
		public Main ()
		{
			InitializeComponent ();

			btnMatrixesMultiplication.Clicked += BtnMatrixesMultiplication_Clicked;
			btnIO.Clicked += BtnIO_Clicked;
			btnInterface.Clicked += BtnInterface_Clicked;
		}

		void BtnInterface_Clicked (object sender, EventArgs e)
		{

			Navigation.PushAsync (new Interface ());
		}

		void BtnIO_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new IO ());
		}

		void BtnMatrixesMultiplication_Clicked (object sender, EventArgs e)
		{
			
			Navigation.PushAsync (new MatrixMultiply ());
		}

	}
}

