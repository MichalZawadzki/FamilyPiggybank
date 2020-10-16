using Microsoft.AspNetCore.Mvc;

namespace FamilyPiggybank.API.Controllers
{
    public class HomeController : ApiController
    {
        //[Authorize]
        public IActionResult Get()
        {
            return Ok("works");
        }
        
    }
}
