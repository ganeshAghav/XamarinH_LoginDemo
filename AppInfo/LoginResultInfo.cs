using System;
using System.Collections.Generic;
using System.Text;

namespace AppInfo
{
    public class LoginResultInfo
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginCount { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public int ChanID { get; set; }
        public string LastDownloadDate { get; set; }
        public bool IsDownloaded { get; set; }
    }

    public class LoginResultInfoList
    {
        public List<LoginResultInfo> loginResultInfos;
    }

}
