using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace TccApp
{
	public partial class Interface : ContentPage
	{

		private const string TAG = "Interface";

		private const int NUMBER_OF_TESTS = 50;

		private Image mImageTested;

		public Interface ()
		{
			InitializeComponent ();

			InitialLoad ();

		}

		private void InitialLoad() {
			btnCalculate.Clicked += BtnCalculate_Clicked;
		}

		void BtnCalculate_Clicked (object sender, EventArgs e) {
			string imageResource = GetFilename ();
			if (imageResource != "") {
				if (Device.OS.ToString ().ToUpper () == "ANDROID") {
					ExecuteTestsOnAndroid (imageResource);
				}
			} else {
				DisplayAlert ("", "Favor selecionar uma imagem e um tamanho para a imagem", "OK");
			}
		}

		private async Task ExecuteTestsOnAndroid(string imageResource) {
			double averageTime = 0;
			double shortestTime = Double.MaxValue;
			double largestTime = Double.MinValue;
			double totalTime = 0;
			long startTimestamp, endTimestamp;
			long [] eachExecutionTime = new long[NUMBER_OF_TESTS];
			if(imageResource != "") {
				startTimestamp = (long)DateTime.UtcNow.ToUniversalTime ().Subtract (
					new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

				for (int q = 0; q < NUMBER_OF_TESTS; q++) {
				



					DateTime startTime = DateTime.Now;

					await LoadImageAssync (imageResource);
					//imgTestedImage.Source = imageResource;

					DateTime endTime = DateTime.Now;
					TimeSpan diffTime = endTime - startTime;

					eachExecutionTime [q] = (long)diffTime.TotalMilliseconds;

					if (diffTime.TotalMilliseconds < shortestTime) {
						shortestTime = diffTime.TotalMilliseconds;
					}

					if (diffTime.TotalMilliseconds > largestTime) {
						largestTime = diffTime.TotalMilliseconds;
					}
					totalTime += diffTime.TotalMilliseconds;

					if (q != NUMBER_OF_TESTS - 1) {
						////stkImage.Children.RemoveAt (0);
						//imgTestedImage2.Source = null;
						////GC.Collect ();
						stkImage.Children.Remove(mImageTested);
						mImageTested = null;

						GC.Collect ();

					}


					//System.GC.Collect ();
				}

				endTimestamp = (long)DateTime.UtcNow.ToUniversalTime ().Subtract (
					new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

				averageTime = totalTime / NUMBER_OF_TESTS;

				double averageTimeInSeconds = averageTime / 1000;
				double shortestTimeInSeconds = shortestTime / 1000;
				double largestTimeInSeconds = largestTime / 1000;
				double totalTimeInSeconds = totalTime / 1000;

				ShowResults (averageTimeInSeconds, shortestTimeInSeconds, largestTimeInSeconds, totalTimeInSeconds, 
					startTimestamp, endTimestamp, eachExecutionTime);

			}
		}

		private async Task LoadImageAssync(string imageURI) {
			//System.Uri uri;
			//System.Uri.TryCreate(imageURI, UriKind.Absolute, out uri);
			//var imgTestedImage = new Image { Aspect = Aspect.AspectFit };
			mImageTested = new Image { Aspect = Aspect.AspectFit };

			Task<ImageSource> result = Task<ImageSource>.Factory.StartNew(() => ImageSource.FromFile(imageURI));
			//imgTestedImage2.Source = await result;
			mImageTested.Source = await result;
			
			//stkImage.Children.Add (imgTestedImage);
			stkImage.Children.Add(mImageTested);
		}

		private string GetFilename() {
			string filename = "";
			switch (pckImage.SelectedIndex) {
			case 0: 
				filename = "ford_";
				break;
			case 1:
				filename = "guitar_";
				break;
			case 2:
				filename = "skyline_";
				break;
			default:
				filename = "";
				break;
			}
			if (filename != "") {
				switch (pckSize.SelectedIndex) {
				case 0:
					filename += "640";
					break;
				case 1:
					filename += "1280";
					break;
				case 2:
					filename += "1920";
					break;
				default:
					filename += "";
					break;
				}
			}

			return filename.Length > 0 && !filename.EndsWith("_") ? filename + ".jpg" : "";
		}

		private void ShowResults(double averageTimeInSeconds, double shortestTimeInSeconds, double largestTimeInSeconds,
			double totalTimeInSeconds, long startTimestamp, long endTimestamp, long[] eachExecutionTime) {

			lblStartTimestamp.Text = "Timestamp inicial: " + startTimestamp;

			lblAverageTime.Text = "Tempo médio: " + averageTimeInSeconds.ToString () + " segundos.";
			lblShortestTime.Text = "Menor tempo: " + shortestTimeInSeconds.ToString () + " segundos.";
			lblLargestTime.Text = "Maior tempo: " + largestTimeInSeconds.ToString () + " segundos.";
			lblTotalTime.Text = "Tempo total: " + totalTimeInSeconds.ToString () + " segundos.";

			lblEndTimestamp.Text = "Timestamp final: " + endTimestamp;
			lblVariance.Text = "Variância: " + Statistics.GetVariance (eachExecutionTime);
			lblStandardDeviation.Text = "Desvio padrão: " + Statistics.GetStandardDeviation (eachExecutionTime);

		}

	}
}

