using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.DAL.DTOs.Request;
using WebApplication1.DAL.DTOs.Response;
using WebApplication1.DAL.Models;

namespace WebApplication1.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.Include(c => c.Translations).ToList();
            var response = categories.Adapt<List<CategoryResponse>>();
            return Ok(response);
        }
        [HttpPost("")]
        public IActionResult Create(CategoryRequest request)
        {
            var category= request.Adapt<Category>();
            _context.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }
       
    }
}
