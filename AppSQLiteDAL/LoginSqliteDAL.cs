using AppInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AppSQLiteDAL
{
    public class LoginSqliteDAL : IPCVCUIService
    {
        private static string TAG = "LoginSqliteDAL:- ";
        private DBPlatformInfo dbPlatform = null;

        public LoginSqliteDAL(DBPlatformInfo dbPlatform)
        {
            this.dbPlatform = dbPlatform;
        }

        public LoginResultInfo ValidateUser(LoginResultInfo loginResultInfo)
        {
            StringBuilder sbQuery = null;
            List<LoginResultInfo> loginResultInfoList = null;
            LoginResultInfo loginResultInfodata = null;

            try
            {
                loginResultInfoList = new List<LoginResultInfo>();
                loginResultInfodata = new LoginResultInfo();

                using (var commonDAL = new CommonDAL(dbPlatform))
                {
                    using (var sqliteConnection = commonDAL.GetSQLiteConnection())
                    {
                        sbQuery = new StringBuilder();
                        sbQuery.Append("SELECT * FROM UserMast ");
                        sbQuery.Append("WHERE UserName = '" + loginResultInfo.UserName + "' ");
                        sbQuery.Append("AND Password = '" + loginResultInfo.Password + "'");
                        loginResultInfoList = sqliteConnection.Query<LoginResultInfo>(sbQuery.ToString() + " ", "");

                        loginResultInfodata = loginResultInfoList[0];
                        commonDAL.Dispose();
                        sqliteConnection.Close();
                        sqliteConnection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(TAG,ex.ToString());
            }
            return loginResultInfodata;
        }

    }
}
