using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalManagementAPI.DataModel.Helper
{
    public class EmailNotification
    {
        public static string Emailnotification()
        {
            MailMessage message = new MailMessage("raghushivaynar@gmail.com", "raghutiptur10@gmail.com");
            message.Subject = "New request from employee";
            message.Body = "You have request for approval";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.UserName = "raghutiptur10@gmail.com";
            credential.Password = "Raghuks123";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(message);

            return "Success";
        }
    }
}
