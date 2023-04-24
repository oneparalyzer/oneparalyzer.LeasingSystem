
using Microsoft.AspNetCore.Mvc;

namespace oneparalyzer.LeasingSystem.Cars.Api.Controllers;

[Route("leasing/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllCars()
    {
        return Ok();
    }
}
