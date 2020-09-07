using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AppBridgeFactory;
using AppInfo;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;

namespace LoginDemo.Classes
{
    public class CommonFunctions
    {
        public static string TAG = "CommonFunctions:- ";
       
        public static string GetAppVersion(Context context)
        {
            string version = string.Empty;
            try
            {
                string verName = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;

                //if (!string.IsNullOrEmpty(verName))
                //{
                //    if (CommonFunctions.GetBASEURL().Equals("https://psc.tataaia.com/PSC"))
                //    {
                //        version = "PROD " + verName;
                //    }
                //    else
                //    {
                //        version = "UAT " + verName;
                //    }
                //}

                version = "App Version: " + verName;
            }
            catch (Exception ex)
            {
                Log.Debug(TAG, ex.ToString());
            }
            return version;

        }

        public static void ShowAlert(Context ctxContext, string title, string message)
        {
            var builder = new AlertDialog.Builder(ctxContext);
            var alertDialog = builder.Create();
            alertDialog.SetTitle(title);
            alertDialog.SetMessage(message);
            alertDialog.SetButton("Close", (s, ev) => { });
            alertDialog.Show();
            alertDialog.SetCancelable(false);
        }

        public static DBPlatformInfo GetPCLConnection(Context context)
        {
            DBPlatformInfo dbPlatformInfo = null;

            try
            {
                var dataPath = String.Format("/data/data/{0}/files", Application.Context.PackageName);
                var connectionString = Path.Combine(dataPath, CommonVariables.SqliteDBName);
                
                dbPlatformInfo = new DBPlatformInfo();
                ISQLitePlatform sqliteDBPlatform = null;
                sqliteDBPlatform = new SQLitePlatformAndroid();
                dbPlatformInfo.SQLDBPath = connectionString;
                dbPlatformInfo.SQLitePlatform = sqliteDBPlatform;

            }
            catch (Exception ex) { Console.WriteLine(TAG, ex.ToString()); }
            return dbPlatformInfo;
        }

        public static LoginResultInfo ValidateUserDetails(Context context,string userID,string password)
        {
            LoginResultInfo loginResultInfo=null;
            LoginResultInfo loginInputInfo = null;
            DBPlatformInfo platformInfo = null;
            IPCVCUIService iuseruiservice = null;

            try
            {
                loginResultInfo = new LoginResultInfo();
                platformInfo = CommonFunctions.GetPCLConnection(context);
                iuseruiservice = BridgeFactory.GetUserManagementUIService(platformInfo);

                loginInputInfo = new LoginResultInfo();
                loginInputInfo.UserName = userID;
                loginInputInfo.Password = password;
                loginResultInfo = iuseruiservice.ValidateUser(loginInputInfo);

            }
            catch(Exception ex)
            {
                Log.Debug(TAG, ex.ToString());
            }
            return loginResultInfo;
        }

    }
}