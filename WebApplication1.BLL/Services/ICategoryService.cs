using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.DAL.DTOs.Request;
using WebApplication1.DAL.DTOs.Response;
using WebApplication1.DAL.Models;

namespace WebApplication1.BLL.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponse> CreateAsync(CategoryRequest request);
        Task<List<CategoryResponse>> GetAllAsync();
    }
}
