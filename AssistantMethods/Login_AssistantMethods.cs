using Herfa_FinalProject.POM;
using Herfa_FinalProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa_FinalProject.AssistantMethods
{
    public class Login_AssistantMethods
    {
        public static void FillLoginForm(string email, string password)
        {
            LoginPage loginPage = new LoginPage(ManageDriver.driver);
            loginPage.EnterEmail(email);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();

        }
    }
}
