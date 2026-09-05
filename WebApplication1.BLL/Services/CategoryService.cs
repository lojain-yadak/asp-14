using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;

using WebApplication1.DAL.DTOs.Request;
using WebApplication1.DAL.DTOs.Response;
using WebApplication1.DAL.Models;
using WebApplication1.DAL.Repository;
using Mapster;
using System.Linq.Expressions;
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
          var categories = await _categoryRepository.GetAllAsync(new string[] {nameof(Category.Translations)});
            var response = categories.Adapt<List<CategoryResponse>>();
            return response;
        }

        public async Task<CategoryResponse> GetCategory(Expression<Func<Category, bool>> filter, string[]? includes = null)
        {
            var category = await _categoryRepository.GetOne(filter, new string[] { nameof(Category.Translations) });
            return category.Adapt<CategoryResponse>();
        }

        public async Task<bool> UpdateCategory(CategoryRequest request, Expression<Func<Category, bool>> filter)
        {
            var category = await _categoryRepository.GetOne(filter,new string[] { nameof(Category.Translations) });
            if (category == null)
            {
                return false;
            }

            request.Adapt(category); 
            await _categoryRepository.UpdateAsync(category);

            return true;
        }
        public async Task<bool> DeleteCategory(int id)
        {
           var category = await _categoryRepository.GetOne(c => c.Id == id);
            if(category == null)
            {
                return false;
            }
            return await _categoryRepository.DeleteAsync(category);
        }
    }
}
