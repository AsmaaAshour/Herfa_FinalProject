using Herfa_FinalProject.AssistantMethods;
using Herfa_FinalProject.Data;
using Herfa_FinalProject.Helpers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa_FinalProject.TestMethods
{
    [TestClass]
    public class ContactUs_TestMethod
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Herfa Final Project\\Herfareport\\");


        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            extentReports.AttachReporter(reporter);

            ManageDriver.MaximizeDriver();
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            extentReports.Flush();

            ManageDriver.CloseDriver();
        }

        [TestInitialize]
        public void Setup()
        {
            CommonMethods.NavigateToURL(GlobalConstants.loginLink);
            Login_AssistantMethods.FillLoginForm("linaalaashqar@gmail.com", "123456");

            CommonMethods.NavigateToURL(GlobalConstants.contactuslink);
        }


        [TestMethod]
        public void SendMessageWithValidInfo()
        {
            var test = extentReports.CreateTest("TestSuccessfully_SendMessage", "TestSuccessfully_SendMessage");
            try
            {
                Info info1 = ContactUs_AssistentMethods.ReadContactUsDataFromExcel(2);
                ContactUs_AssistentMethods.FillContactUsForm(info1);

                Assert.IsTrue(ContactUs_AssistentMethods.CheckSuccessSendContactUsForm(info1.email),
                              "The message was not found in the database for the provided email.");

                var expectedURL = "https://localhost:44349/User/ContactUs";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL does not match expected URL");

                Console.WriteLine("TC1 Completed Successfully");
                test.Pass("ContactUs form sent successfully");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }

        [TestMethod]
        public void SendEmptyMessage()
        {
            var test = extentReports.CreateTest("TestFailed_SendEmptyMessage", "TestFailed_SendEmptyMessage");
            try
            {
                Info info1 = ContactUs_AssistentMethods.ReadContactUsDataFromExcel(3);
                ContactUs_AssistentMethods.FillContactUsForm(info1);

                Assert.IsFalse(ContactUs_AssistentMethods.CheckSuccessSendContactUsForm(info1.email),
                               "Form should not have been submitted successfully with empty message.");

                var expectedURL = "https://localhost:44349/User/ContactUs";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL does not match expected URL");

                Console.WriteLine("TC2 Completed Successfully");
                test.Pass("Displayed error message as expected for empty message");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }

        [TestMethod]
        public void SendAllFieldsEmpty()
        {
            var test = extentReports.CreateTest("TestFailed_SendAllFieldsEmpty", "TestFailed_SendAllFieldsEmpty");
            try
            {
                Info info1 = ContactUs_AssistentMethods.ReadContactUsDataFromExcel(4);
                ContactUs_AssistentMethods.FillContactUsForm(info1);

                Assert.IsFalse(ContactUs_AssistentMethods.CheckSuccessSendContactUsForm(info1.email),
                               "Form should not have been submitted successfully with all fields empty.");

                var expectedURL = "https://localhost:44349/User/ContactUs";
                var actualURL = ManageDriver.driver.Url;
                Assert.AreEqual(expectedURL, actualURL, "Actual URL does not match expected URL");

                Console.WriteLine("TC3 Completed Successfully");
                test.Pass("Displayed error message as expected for all fields empty");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void NullAndInvalidEmails()
        {
            var test = extentReports.CreateTest("TestInvalidEmails", "TestInvalidEmails");

            
            int startRow = 5;  
            int endRow = 8; 

            try
            {
                for (int row = startRow; row <= endRow; row++)
                {
                    Info info1 = ContactUs_AssistentMethods.ReadContactUsDataFromExcel(row);
                    ContactUs_AssistentMethods.FillContactUsForm(info1);

                    bool isSubmissionSuccessful = ContactUs_AssistentMethods.CheckSuccessSendContactUsForm(info1.email);
                    Assert.IsFalse(isSubmissionSuccessful, $"Form should not be submitted with invalid email in row {row}.");

                    test.Pass($"Error displayed for invalid email in row {row}");
                }
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void NullAndInvalidPhoneNumbers()
        {
            var test = extentReports.CreateTest("TestInvalidPhoneNumbers", "TestInvalidPhoneNumbers");

            int startRow = 9; 
            int endRow = 12;   

            try
            {
                for (int row = startRow; row <= endRow; row++)
                {
                    CommonMethods.NavigateToURL(GlobalConstants.contactuslink);

                    Info info1 = ContactUs_AssistentMethods.ReadContactUsDataFromExcel(row);
                    ContactUs_AssistentMethods.FillContactUsForm(info1);

                    bool isSubmissionSuccessful = ContactUs_AssistentMethods.CheckSuccessSendContactUsForm(info1.email);
                    Assert.IsFalse(isSubmissionSuccessful, $"Form should not be submitted with invalid phone number in row {row}.");

                    test.Pass($"Error displayed for invalid phone number in row {row}.");
                }
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }



        [TestMethod]
        public void NameFieldValidation()
        {
            var test = extentReports.CreateTest("TestNameFieldValidation", "TestNameFieldValidation");
           
            int startRow = 13; 
            int endRow = 16;    

            try
            {
                for (int row = startRow; row <= endRow; row++)
                {
                    Info info1 = ContactUs_AssistentMethods.ReadContactUsDataFromExcel(row);
                    ContactUs_AssistentMethods.FillContactUsForm(info1);

                    string nameInput = info1.name;

                    if (ContactUs_AssistentMethods.IsValidName(nameInput))
                    {
                        bool isSubmissionSuccessful = ContactUs_AssistentMethods.CheckSuccessSendContactUsForm(info1.email);
                        Assert.IsTrue(isSubmissionSuccessful, $"Form should be submitted successfully for valid name '{nameInput}' in row {row}.");
                        test.Pass($"Form submitted successfully with valid name '{nameInput}' in row {row}.");
                    }
                    else
                    {
                        bool isSubmissionSuccessful = ContactUs_AssistentMethods.CheckSuccessSendContactUsForm(info1.email);
                        Assert.IsFalse(isSubmissionSuccessful, $"Form should not be submitted for invalid name '{nameInput}' in row {row}.");
                        test.Pass($"Error displayed as expected for invalid name '{nameInput}' in row {row}.");
                    }
                }
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }
    }
}
