using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInfo
{
    public enum DBPlatformType : byte
    {
        SQLite = 1, SQLServer, MSAccess, Oracle
    }

    public class DBPlatformInfo 
    {
        public DBPlatformType PlatformType;
        public ISQLitePlatform SQLitePlatform;
        public string SQLDBPath;

    }

}
