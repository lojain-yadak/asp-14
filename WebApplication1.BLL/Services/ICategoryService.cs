using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        Task<CategoryResponse> GetCategory(Expression<Func<Category, bool>> filter, string[]? includes = null);
        Task<bool> UpdateCategory(CategoryRequest request, Expression<Func<Category, bool>> filter);
        Task<bool> DeleteCategory(int id);
    }
}
