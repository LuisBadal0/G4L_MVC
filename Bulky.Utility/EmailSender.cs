using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreG.Utility
{
    public class EmailSender :IEmailSender
    {
        public string SendGridSecret {  get; set; }

        public EmailSender(IConfiguration _config) {

            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //login to send email

            var client = new SendGridClient(SendGridSecret);

            //Same email configured in SendGrid(doesn't work with already hosted emails (gmail,outlook,etc...))
            var from = new EmailAddress("geral@storeg.com", "StoreG");
            var to = new EmailAddress(email);
            var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            return client.SendEmailAsync(message);
        }
    }
}
