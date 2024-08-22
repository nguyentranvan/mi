using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MI.Controller.Lib;
using MI.DBContext.Models;
using Microsoft.EntityFrameworkCore;
namespace Lms.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeatherForecastController : MIController
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DBContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var db = await _dbContext.Eclasses.CountAsync();
            return Ok(DisplayName + db);
        }
    }
}
