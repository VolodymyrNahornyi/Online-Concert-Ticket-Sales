using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models.Concerts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineConcertTicketSales.ActionFilters;

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
        public async Task<IActionResult> GetArtistsForGenreAsync(Guid genreId)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(genreId, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistsFromDb = await _serviceManager.Artist.GetArtistsAsync(genreId, false);

            var artistsDto = _mapper.Map<IEnumerable<ArtistDto>>(artistsFromDb);
            return Ok(artistsDto);
        }

        [HttpGet("{id}", Name = "GetArtistForGenre")]
        public async Task<IActionResult> GetArtistForGenre(Guid genreId, Guid id)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(genreId, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistFromDb = await _serviceManager.Artist.GetArtistAsync(genreId, id, false);
            if (artistFromDb == null)
            {
                _logger.LogInfo($"Artist with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var artistDto = _mapper.Map<ArtistDto>(artistFromDb);

            return Ok(artistDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateArtistForGenre(Guid genreId, [FromBody]ArtistForCreationDto artist)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(genreId, false);
            if (genre == null)
            {
                _logger.LogError($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistEntity = _mapper.Map<Artist>(artist);
            
            _serviceManager.Artist.CreateArtist(genreId, artistEntity);
            await _serviceManager.SaveAsync();

            var artistToReturn = _mapper.Map<ArtistDto>(artistEntity);

            return CreatedAtRoute("GetArtistForGenre", new {genreId, id = artistToReturn.Id},
                artistToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateArtistForGenreExistsAttribute))]
        public async Task<IActionResult> DeleteArtistForGenre(Guid genreId, Guid id)
        {
            var artistForGenre = HttpContext.Items["artistForGenre"] as Artist;
            
            _serviceManager.Artist.DeleteArtist(artistForGenre);
            await _serviceManager.SaveAsync();

            _logger.LogInfo($"Artist with id: {id} is deleted successfully.");
            
            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateArtistForGenreExistsAttribute))]
        public async Task<IActionResult> UpdateArtistForGenre(Guid genreId, Guid id, [FromBody] ArtistForUpdateDto artist)
        {
            var artistEntity = HttpContext.Items["artistForGenre"] as Artist;
            
            _mapper.Map(artist, artistEntity);
            await _serviceManager.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateArtistForGenreExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateArtistForGenre(Guid genreId, Guid id,
            [FromBody] JsonPatchDocument<ArtistForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }
            
            var artistEntity = HttpContext.Items["artistForGenre"] as Artist;

            var artistToPatch = _mapper.Map<ArtistForUpdateDto>(artistEntity);
            
            patchDoc.ApplyTo(artistToPatch, ModelState);
            
            TryValidateModel(artistToPatch);
            
            if(!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(artistToPatch, artistEntity);
            
            await _serviceManager.SaveAsync();

            return NoContent();
        }
    }
}