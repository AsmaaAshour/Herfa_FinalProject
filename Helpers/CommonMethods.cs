﻿using Bytescout.Spreadsheet;
using Herfa_FinalProject.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa_FinalProject.Helpers
{
    public class CommonMethods
    {
        public static void NavigateToURL(string url)
        {
            ManageDriver.driver.Navigate().GoToUrl(url);
        }


        public static IWebElement WaitAndFindElement(By by)
        {
            var fluentWait = new DefaultWait<IWebDriver>(ManageDriver.driver)
            {
                Timeout = TimeSpan.FromSeconds(20),
                PollingInterval = TimeSpan.FromMilliseconds(1000),
            };

            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement element = fluentWait.Until(x => x.FindElement(by));

            return element;
        }


        public static void HighlightElement(IWebElement element)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)ManageDriver.driver;

            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: lightblue !important')", element);

            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Thread.Sleep(1000);

            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: none !important')", element);
        }


        public static Worksheet ReadExcel(string sheetName)
        {
            Spreadsheet Excel = new Spreadsheet();

            Excel.LoadFromFile(GlobalConstants.TestDataPath);

            Worksheet worksheet = Excel.Workbook.Worksheets.ByName(sheetName);

            return worksheet;
        }


        public static string TakeScreenShot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)ManageDriver.driver;

            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string path = "C:\\Herfa Final Project\\Herfareport\\screenshots";

            string imageName = Guid.NewGuid().ToString() + "_image.png";

            string fullPath = Path.Combine(path + $"\\{imageName}");

            screenshot.SaveAsFile(fullPath);

            return fullPath;
        }
    }
}