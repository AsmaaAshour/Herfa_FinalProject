using Herfa_FinalProject.POM;
using Herfa_FinalProject.AssistantMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfa_FinalProject.Data
{
    public class Info
    {
        public Info() { }

        public Info(string name, string email, string phone, string subject,
                    string message)
        {                          
            this.name = name;                 
            this.email = email;                     
            this.phone = phone;           
            this.subject = subject;                       
            this.message = message;             
        }

        public string name { get; set; }        
        public string email { get; set; }         
        public string phone { get; set; }            
        public string subject { get; set; }      
        public string message { get; set; }            
    }
}