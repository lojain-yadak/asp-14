using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.BLL.Common
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
