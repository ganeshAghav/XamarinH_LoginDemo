using AppInfo;
using AppSQLiteDAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AppBL
{
    public class LoginBAL : IPCVCUIService
    {
        private static string TAG = "LoginBAL:- ";
        private DBPlatformInfo dbPlatform = null;
        
        public LoginBAL(DBPlatformInfo dbPlatform)
        {
            this.dbPlatform = dbPlatform;
        }

        public LoginResultInfo ValidateUser(LoginResultInfo loginResultInfo)
        {
            LoginSqliteDAL iLoginSqliteDAL = null;
            LoginResultInfo ResultInfo = null;

            try
            {
                iLoginSqliteDAL = new LoginSqliteDAL(dbPlatform);
                ResultInfo = iLoginSqliteDAL.ValidateUser(loginResultInfo);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(TAG,ex.ToString());
            }
            finally
            {
                iLoginSqliteDAL = null;
            }
            return ResultInfo;
        }

    }
}
