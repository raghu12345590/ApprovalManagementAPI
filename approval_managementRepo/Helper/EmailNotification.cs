using ApprovalManagementAPI.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace ApprovalManagementAPI.DataModel.Helper
{
    public class EmailNotification
    {
        public static string Emailnotification(string managerEmail, RequestDetail request)
        {
            MailMessage message = new MailMessage("approvalmanagement3@gmail.com", managerEmail);
            message.Subject = "New request from Employee";
           
            message.Body = "you recive a new request from employee";
           // Client.UseDefaultCredentials = true;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.UserName = "approvalmanagement3@gmail.com";
            credential.Password = "aguandawyaqpqmqy";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(message);


            return "Success";
        }

        public static string AcceptNotification(string managerEmail)
        {
            MailMessage message = new MailMessage("approvalmanagement3@gmail.com", managerEmail);
            message.Subject = "New request from Employee";
            message.Body = "You have request for approval";
            // Client.UseDefaultCredentials = true;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.UserName = "approvalmanagement3@gmail.com";
            credential.Password = "aguandawyaqpqmqy";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(message);


            return "Success";
        }

        public static string RejectNotification(string managerEmail)
        {
            MailMessage message = new MailMessage("approvalmanagement3@gmail.com", managerEmail);
            message.Subject = "New request from Employee";
            message.Body = "You have request for approval";
            // Client.UseDefaultCredentials = true;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.UserName = "approvalmanagement3@gmail.com";
            credential.Password = "aguandawyaqpqmqy";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(message);


            return "Success";
        }
    }
}
