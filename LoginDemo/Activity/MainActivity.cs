using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Support.V4.App;
using Android;
using Android.Content.PM;
using Android.Webkit;
using LoginDemo.Controller;
using LoginDemo.Classes;
using System;

namespace LoginDemo
{
    [Activity(Label = "LoginDemo", NoHistory = false, Theme = "@style/AppTheme1", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.AdjustPan)]
    public class MainActivity : AppCompatActivity
    {
        private static string TAG = "MainActivity";
        static string[] PERMISSIONS_READ = {
        Manifest.Permission.ReadExternalStorage
        };
        static string[] PERMISSIONS_WRITE = {
        Manifest.Permission.WriteExternalStorage
        };
        private const int REQUEST_READ = 1;
        private const int REQUEST_WRITE = 2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            ResourceManager.EnsureResources(
                        typeof(ModelViewUI.IDataAccess).Assembly,
                        String.Format("/data/data/{0}/files", Application.Context.PackageName));

            ReqReadStorgePermission();
        }

        public void ReqReadStorgePermission()
        {
           
            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == (int)Permission.Granted)
            {
                ReqWriteStorgePermission();
            }
            else
            {
                ActivityCompat.RequestPermissions(this, PERMISSIONS_READ, REQUEST_READ);
            }
        }

        public void ReqWriteStorgePermission()
        {

            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
            {
                LoadPage();
            }
            else
            {
                ActivityCompat.RequestPermissions(this, PERMISSIONS_WRITE, REQUEST_WRITE);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            switch (requestCode)
            {
                case REQUEST_READ:
                {
                    if (grantResults[0] == (int)Permission.Granted)
                    {
                        ReqReadStorgePermission();
                    }
                    else
                    {
                        Toast.MakeText(this, "Read Permission Denied", ToastLength.Long).Show();
                    }
                }
                break;

                case REQUEST_WRITE:
                {
                    if (grantResults[0] == (int)Permission.Granted)
                    {
                        LoadPage();
                    }
                    else
                    {
                        Toast.MakeText(this, "Write Permission Denied", ToastLength.Long).Show();
                    }
                }
                break;
            }
        }

        public void LoadPage()
        {
            var webView = FindViewById<WebView>(Resource.Id.webView);
            PortableRazor.RouteHandler.Controllers.Clear();
            var loginController = new LoginController(new HybridWebView(webView),this);

            PortableRazor.RouteHandler.RegisterController("LoginController", loginController);
            loginController.OnCreate();
        }


    }
}