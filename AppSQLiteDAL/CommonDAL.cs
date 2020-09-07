using AppInfo;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AppSQLiteDAL
{
    internal class CommonDAL : IDisposable
    {
        private static string TAG = "CommonDAL:- ";
        private ISQLitePlatform sqlitePlatform = null;
        private string sqliteDBPath = null;

        internal CommonDAL(DBPlatformInfo dbPlatform)
        {
            sqliteDBPath = dbPlatform.SQLDBPath;
            sqlitePlatform = dbPlatform.SQLitePlatform;
        }

        public SQLite.Net.SQLiteConnection GetSQLiteConnection()
        {
            SQLite.Net.SQLiteConnection dbConn = null;
            try
            {
                dbConn = new SQLite.Net.SQLiteConnection(sqlitePlatform, sqliteDBPath, false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(TAG,ex.ToString());
            }
            return dbConn;
        }

        public void Dispose()
        {
            sqlitePlatform = null;
        }

    }
}