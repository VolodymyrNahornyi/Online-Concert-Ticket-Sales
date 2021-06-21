using System;
using System.Collections.Generic;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models.Concerts;
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

        [HttpGet]
        public IActionResult GetArtistsForGenre(Guid genreId)
        {
            var genre = _serviceManager.Genre.GetGenre(genreId, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistsFromDb = _serviceManager.Artist.GetArtists(genreId, false);

            var artistsDto = _mapper.Map<IEnumerable<ArtistDto>>(artistsFromDb);
            return Ok(artistsDto);
        }

        [HttpGet("{id}", Name = "GetArtistForGenre")]
        public IActionResult GetArtistForGenre(Guid genreId, Guid id)
        {
            var genre = _serviceManager.Genre.GetGenre(genreId, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistFromDb = _serviceManager.Artist.GetArtist(genreId, id, false);
            if (artistFromDb == null)
            {
                _logger.LogInfo($"Artist with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var artistDto = _mapper.Map<ArtistDto>(artistFromDb);

            return Ok(artistDto);
        }

        [HttpPost]
        public IActionResult CreateArtistForGenre(Guid genreId, [FromBody]ArtistForCreationDto artist)
        {
            if (artist == null)
            {
                _logger.LogError("ArtistForCreationDto object sent from client is null.");
                return BadRequest("ArtistForCreationDto  object is null");
            }

            var genre = _serviceManager.Genre.GetGenre(genreId, false);
            if (genre == null)
            {
                _logger.LogError($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistEntity = _mapper.Map<Artist>(artist);
            
            _serviceManager.Artist.CreateArtist(genreId, artistEntity);
            _serviceManager.Save();

            var artistToReturn = _mapper.Map<ArtistDto>(artistEntity);

            return CreatedAtRoute("GetArtistForGenre", new {genreId, id = artistToReturn.Id},
                artistToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArtistForCompany(Guid genreId, Guid id)
        {
            var genre = _serviceManager.Genre.GetGenre(genreId, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistForGenre = _serviceManager.Artist.GetArtist(genreId, id, false);

            if (artistForGenre == null)
            {
                _logger.LogInfo($"Artist with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            
            _serviceManager.Artist.DeleteArtist(artistForGenre);
            _serviceManager.Save();

            return NoContent();
        }
    }
}