using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.BLL.Common;
using WebApplication1.DAL.DTOs.Request;
using WebApplication1.DAL.DTOs.Response;
using WebApplication1.DAL.Models;

namespace WebApplication1.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AuthenticationService(UserManager<ApplicationUser> userManager,IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new LoginResponse { Message = "Invalid email or password." };
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
            {
                return new LoginResponse { Message = "Invalid email or password." };
            }

            return new LoginResponse { Message = "Login successful." };
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
          var user=request.Adapt<ApplicationUser>();
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) { 
             return new RegisterResponse { Message = "User registration failed." };
            }
            var emailUrl = "https://localhost:7081/api/Account/ConfirmEmail?email={request.Email}";
            await _emailSender.SendEmailAsync(request.Email, "Welcome!", "<div> <h1>Thank you for registering.</h1> " +
                "<a href=\"" + emailUrl + "\">Confirm Email</a> </div>");
            return new RegisterResponse { Message = "User registered successfully." };
        }
    }
}
