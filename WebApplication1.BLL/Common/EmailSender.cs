using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace WebApplication1.BLL.Common
{
    public class EmailSender : IEmailSender
    {
      public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("lojainmustafa2000@gmail.com", "vnto fkke zioa yohj")
            };
            return client.SendMailAsync(
                    new MailMessage(from: "lojainmustafa2000@gmail.com", 
                    to: email,
                    subject,
                    message)
                    { IsBodyHtml = true }
                    );


        }
    }
}
