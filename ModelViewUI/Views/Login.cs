#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelViewUI.Views
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 2 "Login.cshtml"
using PortableRazor;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "4.12.3.83")]
public partial class Login : PortableRazor.ViewBase
{

#line hidden

#line 3 "Login.cshtml"
public ModelViewUI.Models.LoginModel Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("<html");

WriteLiteral(" lang=\"en-US\"");

WriteLiteral(">\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0\"");

WriteLiteral(" />\r\n    <title>َAnimated Login Form</title>\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" href=\"css/style.css\"");

WriteLiteral(">\r\n\r\n    <script");

WriteLiteral(" src=\"jquery-1.10.2.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"jquery.client.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">

        $(document).ready(function () {

        });

        function UserLogin() {
            var password = document.getElementById('txtPassword').value;
            var user = document.getElementById('txtuser').value;

            if (user == """") {
                alert(""Please enter user name."");
            }
            else if (user.length > 10 || user.length < 9) {
                alert(""User name must be 10 digit."");
            }
            else if (password == """") {
                alert(""Please enter password."");
            }
            else if (password.length > 5 || password.length < 4) {
                alert(""Password must be 5 digit."");
            }
            else {
                location.href = '");


#line 38 "Login.cshtml"
                            Write(Url.Action("btnLogin_Click", "LoginController"));


#line default
#line hidden
WriteLiteral("?txtUserName=\' + user + \'&txtPassword=\' + password;\r\n            }\r\n        }\r\n  " +
"  </script>\r\n\r\n</head>\r\n\r\n<body");

WriteLiteral(" style=\"background-color: #191919;\"");

WriteLiteral(">\r\n\r\n    <div");

WriteLiteral(" class=\"box\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" style=\"font-family: monospace;color: white;font-weight: 500;\"");

WriteLiteral(">Login</div>\r\n        \r\n        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"\"");

WriteLiteral(" id=\"txtuser\"");

WriteLiteral(" placeholder=\"Username\"");

WriteLiteral(">\r\n        <input");

WriteLiteral(" type=\"password\"");

WriteLiteral(" name=\"\"");

WriteLiteral("  id=\"txtPassword\"");

WriteLiteral(" placeholder=\"Password\"");

WriteLiteral(">\r\n\r\n        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"\"");

WriteLiteral(" value=\"Login\"");

WriteLiteral(" onclick=\"UserLogin()\"");

WriteLiteral(">\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"AppVersion\"");

WriteLiteral(">");


#line 56 "Login.cshtml"
                       Write(Model.AppVersion);


#line default
#line hidden
WriteLiteral("</div>\r\n</body>\r\n</html>\r\n");

}
}
}
#pragma warning restore 1591
