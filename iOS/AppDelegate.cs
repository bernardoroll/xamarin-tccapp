using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using XLabs.Forms;

namespace TccApp.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate //global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}

		public override void WillEnterForeground (UIApplication uiApplication)
		{
			base.WillEnterForeground (uiApplication);
		}

		public override void OnActivated (UIApplication uiApplication)
		{
			base.OnActivated (uiApplication);
		}

	}
		
}

