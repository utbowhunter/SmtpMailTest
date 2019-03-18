using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GmailSmtp
{
    public static class Email
    {
        public static class Smtp
        {
            const int smtpPort = 587;
            const string host = "smtp.gmail.com";


             public static SmtpClient RetrieveSmtpClient(string loginName, string password)
             {
                var smtp = new SmtpClient()
                {
                    Host = host,
                    Port = smtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(loginName, password)
                };

                return smtp;

             }
        }

        public static void SendEmail(string From, string To, string CC, string BCC, string Subject, string Body)
        {
            SmtpClient smtp = Email.Smtp.RetrieveSmtpClient("riverton6bishopric@gmail.com", "Ether1227");

            var from = new MailAddress(From);
            var to = new MailAddress(To);

          

            using (var message = new MailMessage(from, to)
            {
                Subject = Subject,
                Body = Body
            })
            {
                smtp.Send(message);
            }


        }



    }
}
