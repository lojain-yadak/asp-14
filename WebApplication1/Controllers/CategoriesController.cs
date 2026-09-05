using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WebApplication1.BLL.Services;
using WebApplication1.DAL;
using WebApplication1.DAL.DTOs.Request;
using WebApplication1.DAL.DTOs.Response;
using WebApplication1.DAL.Models;
using WebApplication1.DAL.Repository;
using WebApplication1.PL.Resources;

namespace WebApplication1.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IStringLocalizer<SharedResources> localizer, ICategoryService categoryService)
        {
            _localizer = localizer;
           
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {

           var category= await _categoryService.GetAllAsync();
            return Ok(category);
        }
        [HttpPost("")]
        public async Task<IActionResult>Create(CategoryRequest request)
        {
           var response= await _categoryService.CreateAsync(request);
            
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategory(c => c.Id == id);
            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryRequest request)
        {
            var result = await _categoryService.UpdateCategory(request, c => c.Id == id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }

}
