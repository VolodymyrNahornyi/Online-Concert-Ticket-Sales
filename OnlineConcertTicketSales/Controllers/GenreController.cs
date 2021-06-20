using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace OnlineConcertTicketSales.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class r : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public r(IServiceManager serviceManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            var genres = _serviceManager.Genre.GetAllGenres(false);

            var genresDto = _mapper.Map<IEnumerable<GenreDto>>(genres);

            return Ok(genresDto);
        }

        [HttpGet("{id}", Name = "GenreById")]
        public IActionResult GetGenre(Guid id)
        {
            var genre = _serviceManager.Genre.GetGenre(id, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var genreDto = _mapper.Map<GenreDto>(genre);
                return Ok(genreDto);
            }
        }
    }
}