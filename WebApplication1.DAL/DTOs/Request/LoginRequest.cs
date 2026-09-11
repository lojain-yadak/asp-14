using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.DAL.DTOs.Request
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
