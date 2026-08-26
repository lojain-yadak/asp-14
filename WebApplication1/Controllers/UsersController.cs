using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        [HttpGet]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult Create(User request)
        {
            _context.Users.Add(request);
            _context.SaveChanges();
            return Ok(request);
        }
        [HttpPatch("{id}")]
        public IActionResult Update(int id, User request)
        {
           request.Id = id;
            _context.Users.Update(request);
            _context.SaveChanges();
            return Ok(new {Message="Success"});
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(new {Message="Success"});
        }
    }
}
