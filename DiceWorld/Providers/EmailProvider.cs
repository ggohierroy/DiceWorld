using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace DiceWorld.Providers
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Credentials:
            const string credentialUserName = "support@diceworld.ca";
            const string sentFrom = "support@diceworld.ca";
            const string pwd = "diceworld";

            // Create the credentials:
            var credentials = new NetworkCredential(credentialUserName, pwd);

            // Configure the client:
            var client = new SmtpClient("smtp.zoho.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true, 
                Credentials = credentials,

            };

            // Create the message:
            var mail = new MailMessage(sentFrom, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            // Send:
            return client.SendMailAsync(mail);
        }
    }
  
}