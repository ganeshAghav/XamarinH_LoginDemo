using System;
using System.Collections.Generic;
using System.Text;

namespace AppInfo
{
    public interface IPCVCUIService
    {
        LoginResultInfo ValidateUser(LoginResultInfo loginResultInfo);
    }
}
