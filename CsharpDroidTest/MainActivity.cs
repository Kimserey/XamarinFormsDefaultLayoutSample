using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Android.Content.PM;

namespace CsharpDroidTest
{
	[Activity(Label = "CsharpDroidTest", Theme = "@style/MyTheme", MainLauncher = true, Icon = "@mipmap/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);
			Xamarin.Forms.Forms.Init(this, bundle);
			this.LoadApplication(new XfDefaultLayoutSample.App());
		}
	}
}


