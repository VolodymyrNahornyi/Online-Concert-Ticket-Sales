using System;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace OnlineConcertTicketSales.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;

        public GenreController(IServiceManager serviceManager, ILoggerManager loggerManager)
        {
            _serviceManager = serviceManager;
            _logger = loggerManager;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            try
            {
                var genres = _serviceManager.Genre.GetAllGenres(false);
                return Ok(genres);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetGenres)} action {ex}");
            return StatusCode(500, "Internal server error");
            }
        }
        
    }
}