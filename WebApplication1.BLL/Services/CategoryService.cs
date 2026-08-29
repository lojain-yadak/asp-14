using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;

using WebApplication1.DAL.DTOs.Request;
using WebApplication1.DAL.DTOs.Response;
using WebApplication1.DAL.Models;
using WebApplication1.DAL.Repository;
using Mapster;
namespace WebApplication1.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryResponse> CreateAsync(CategoryRequest request)
        {

            var category =  request.Adapt<Category>();
           await _categoryRepository.CreateAsync(category);
            return category.Adapt<CategoryResponse>();
           
        }

        public async Task<List<CategoryResponse>> GetAllAsync()
        {
          var categories = await _categoryRepository.GetAllAsync();
            var response = categories.Adapt<List<CategoryResponse>>();
            return response;
        }
    }
}
