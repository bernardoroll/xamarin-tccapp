using System;

using Xamarin.Forms;

namespace TccApp
{
	public class App : Application
	{

		private const string TAG = "App";

		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new Main());
//			MainPage = new ContentPage {
//				Content = new StackLayout {
//					VerticalOptions = LayoutOptions.Center,
//					Children = {
//						new Label {
//							XAlign = TextAlignment.Center,
//							Text = "Welcome to Xamarin Forms!"
//						}
//					}
//				}
//			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			System.Diagnostics.Debug.WriteLine(TAG + "OnStart() called.");
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
			System.Diagnostics.Debug.WriteLine(TAG + "OnSleep() called.");
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
			System.Diagnostics.Debug.WriteLine(TAG + "OnResume() called.");
		}
	}
}

