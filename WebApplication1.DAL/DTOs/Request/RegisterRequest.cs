using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.DAL.DTOs.Request
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
    }
}
