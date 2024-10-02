using OpenQA.Selenium;
using Herfa_FinalProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa_FinalProject.POM
{
    public class ContactUsPage
    {
        IWebDriver _driver;

        public ContactUsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By name = By.XPath("//div/input[@name='Name']");
        By email = By.XPath("//div/input[@name='Email']");
        By phone = By.XPath("//div/input[@name='Phonenumber']");
        By subject = By.XPath("//div/input[@name='Subject']");
        By message = By.XPath("//div/textarea[@id='Message']");
        By submit=By.XPath("//div/button[@type='submit']");
        

        public void EnterName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(name);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }


        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(email);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }


        public void EnterPhone(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(phone);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }


        public void EnterSubject(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(subject);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

     
        public void EnterMessage(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(message);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }


        public void ClickSubmit()
        {
             CommonMethods.WaitAndFindElement(submit).Click();
        }
    }
}