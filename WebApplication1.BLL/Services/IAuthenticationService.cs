using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.DAL.DTOs.Request;
using WebApplication1.DAL.DTOs.Response;

namespace WebApplication1.BLL.Services
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
       
    }
}
