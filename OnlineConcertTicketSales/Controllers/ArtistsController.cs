using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace OnlineConcertTicketSales.Controllers
{
    [Route("api/genres/{genreId}/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ArtistsController(IServiceManager serviceManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _logger = loggerManager;
            _mapper = mapper;
        }
    }
}