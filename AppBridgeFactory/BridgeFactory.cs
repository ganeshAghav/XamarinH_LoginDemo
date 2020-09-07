using AppBL;
using AppInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AppBridgeFactory
{
    public static class BridgeFactory
    {
        public static string TAG = "AppBridgeFactory:- ";

        public static IPCVCUIService GetUserManagementUIService(DBPlatformInfo dbPlatform)
        {
            IPCVCUIService pcvcui = null;

            try
            {
                pcvcui = new LoginBAL(dbPlatform);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(TAG, ex.ToString());
            }
            return pcvcui;
        }

    }
}
