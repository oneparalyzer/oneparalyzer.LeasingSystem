using Microsoft.AspNetCore.Mvc;

namespace oneparalyzer.LeasingSystem.Customers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
