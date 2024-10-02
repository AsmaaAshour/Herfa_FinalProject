using OpenQA.Selenium;
using Herfa_FinalProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa_FinalProject.POM
{
    public class LoginPage
    {
        IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }


        By email = By.XPath("//div/input[@id='Email']");
        By password = By.XPath("//div/input[@id='myPass1']");
        By rememberMe = By.XPath("//div/input[@id='RememberMe']");
        By showPassword = By.XPath("(//div/input[@type='checkbox'])[2]");
        By forgotPassword = By.XPath("//div/a[contains(text(), 'Forgot password?')]");
        By loginButton = By.XPath("//div/button[contains(text(), 'Login')]");
        By registerLink = By.XPath("//p/a[contains(text(), 'Register')]");

        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(email);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }


        public void EnterPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(password);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void ClickRememberMe()
        {
             CommonMethods.WaitAndFindElement(rememberMe).Click();
        }

        public void ClickShowPassword()
        {
            CommonMethods.WaitAndFindElement(showPassword).Click();
        }

        public void ClickForgotPassword()
        {
            CommonMethods.WaitAndFindElement(forgotPassword).Click();
        }
        public void ClickLoginButton()
        {
            CommonMethods.WaitAndFindElement(loginButton).Click();
        }
        public void ClickRegisterLink()
        {
            CommonMethods.WaitAndFindElement(registerLink).Click();
        }
    }
}
