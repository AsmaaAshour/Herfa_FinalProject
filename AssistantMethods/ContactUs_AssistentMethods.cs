using Herfa_FinalProject.POM;
using Herfa_FinalProject.Helpers;
using Herfa_FinalProject.Data;
using Bytescout.Spreadsheet;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa_FinalProject.AssistantMethods
{
    public class ContactUs_AssistentMethods
    {
        public static void FillContactUsForm(Info info)
        {
            string uniqueEmail = Guid.NewGuid().ToString() + "_" + info.email;


            ContactUsPage contactuspage = new ContactUsPage(ManageDriver.driver);
            contactuspage.EnterName(info.name);
            contactuspage.EnterEmail(uniqueEmail);
            contactuspage.EnterPhone(info.phone);
            contactuspage.EnterSubject(info.subject);
            contactuspage.EnterMessage(info.message);
            contactuspage.ClickSubmit();
        }


        public static Info ReadContactUsDataFromExcel(int row)
        {
            Info info = new Info();

            Worksheet worksheet = CommonMethods.ReadExcel("ContactUs");

            info.name = Convert.ToString(worksheet.Cell(row, 2).Value);

            info.email = Convert.ToString(worksheet.Cell(row, 3).Value);

            info.phone = Convert.ToString(worksheet.Cell(row, 4).Value);

            info.subject = Convert.ToString(worksheet.Cell(row, 5).Value);

            info.message = Convert.ToString(worksheet.Cell(row, 6).Value);

            return info;
        }


        public static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length <= 100 && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }


        public static bool CheckSuccessSendContactUsForm(string email)
        {
            bool isMessageSent = false;

            string query = "SELECT COUNT(*) FROM contactus_fp WHERE email = :email";
            try
            {
                using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
                {
                    connection.Open();

                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(new OracleParameter(":email", email));

                    int result = Convert.ToInt32(command.ExecuteScalar());

                    isMessageSent = result > 0;
                }
            }
            

            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
            }
            return isMessageSent;
        }
    }
}