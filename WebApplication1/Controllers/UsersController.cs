using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebApplication1.DAL;

using WebApplication1.PL.Resources;


namespace WebApplication1.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApplicationDbContext _context;
        IOS _os;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public UsersController(ApplicationDbContext context, IOS os, IStringLocalizer<SharedResources> localizer)
        {
            _context = context;
            _os = os;
            _localizer = localizer;
        }
       
        public IActionResult Index()
        {
           
            return Ok( _localizer["Success"].Value);
        }

    }
}
