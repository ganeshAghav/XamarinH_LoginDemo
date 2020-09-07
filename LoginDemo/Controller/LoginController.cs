using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AppInfo;
using LoginDemo.Classes;
using ModelViewUI.Models;
using ModelViewUI.Views;
using PortableRazor;

namespace LoginDemo.Controller
{
    public class LoginController
    {
        private static string TAG = "LoginController:- ";
        private IHybridWebView webView;
        private Context context;

        public LoginController(IHybridWebView webView, Context ctx)
        {
            this.webView = webView;
            this.context = ctx;
        }

        public void OnCreate()
        {
            var loginModel = new LoginModel();

            string AppVern = CommonFunctions.GetAppVersion(context);
            if (!string.IsNullOrEmpty(AppVern))
            {
                loginModel.AppVersion = AppVern;
            }

            var template = new Login { Model = loginModel };
            var page = template.GenerateString();
            webView.LoadHtmlString(page);

        }

        public void btnLogin_Click(string txtUserName, string txtPassword)
        {
            try
            {

                LoginResultInfo loginResultInfo = new LoginResultInfo();
                loginResultInfo = CommonFunctions.ValidateUserDetails(context,txtUserName.Trim().ToString(),txtPassword.Trim().ToString());
                if (loginResultInfo != null && loginResultInfo.UserName!=null && loginResultInfo.Password!=null)
                {
                    if (loginResultInfo.UserName.Equals(txtUserName.Trim().ToString()) && loginResultInfo.Password.Equals(txtPassword.Trim().ToString()))
                    {
                        Toast.MakeText(context, "Login Successfull...", ToastLength.Long).Show();
                    }
                    else
                    {
                        Toast.MakeText(context, "Login Not Successfull...", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(context, "Login Not Successfull...", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Log.Debug(TAG, ex.ToString());
            }
        }


    }
}