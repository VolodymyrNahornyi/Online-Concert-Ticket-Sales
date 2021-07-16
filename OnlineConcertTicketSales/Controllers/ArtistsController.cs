using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models.Concerts;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineConcertTicketSales.ActionFilters;
using OnlineConcertTicketSales.Utility;

namespace OnlineConcertTicketSales.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/genres/{genreId}/artists")]
    [ApiController]
    [Authorize]
    public class ArtistsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<ArtistDto> _dataShaper;
        private readonly ArtistLinks _artistLinks;

        public ArtistsController(IServiceManager serviceManager, ILoggerManager loggerManager, IMapper mapper, IDataShaper<ArtistDto> dataShaper,
            ArtistLinks artistLinks)
        {
            _serviceManager = serviceManager;
            _logger = loggerManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
            _artistLinks = artistLinks;
        }
        
        [HttpGet]
        [HttpHead]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetArtistsForGenreAsync(Guid genreId, [FromQuery] ArtistParameters artistParameters)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(genreId, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistsDto = await _serviceManager.Artist.GetArtistsAsync(genreId, artistParameters, false);

            //Add Pagination MetaData to the Response
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(artistsDto.MetaData));
            
            var links = _artistLinks.TryGenerateLinks(artistsDto.ArtistsDto, artistParameters.Fields,
                genreId, HttpContext);
            
            return links.HasLinks ? Ok(links.LinkedEntities) : Ok(links.ShapedEntities);
        }

        [HttpGet("{id}", Name = "GetArtistForGenre")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetArtistForGenre(Guid genreId, Guid id, [FromQuery] ArtistParameters artistParameters)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(genreId, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }

            var artistDto = await _serviceManager.Artist.GetArtistAsync(genreId, id, false);
            if (artistDto == null)
            {
                _logger.LogInfo($"Artist with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            return Ok(_dataShaper.ShapeData(artistDto, artistParameters.Fields));
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateArtistForGenre(Guid genreId, [FromBody] ArtistForCreationDto artist)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(genreId, false);
            if (genre == null)
            {
                _logger.LogError($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }
            
            var artistToReturn = await _serviceManager.Artist.CreateArtist(genreId, artist);

            return CreatedAtRoute("GetArtistForGenre", new {genreId, id = artistToReturn.Id},
                artistToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateArtistForGenreExistsAttribute))]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteArtistForGenre(Guid genreId, Guid id)
        {
            var artistForGenre = HttpContext.Items["artistForGenre"] as Artist;

            await _serviceManager.Artist.DeleteArtist(artistForGenre);

            _logger.LogInfo($"Artist with id: {id} is deleted successfully.");
            
            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateArtistForGenreExistsAttribute))]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateArtistForGenre(Guid genreId, Guid id, [FromBody] ArtistForUpdateDto artist)
        {
            var artistEntity = HttpContext.Items["artistForGenre"] as Artist;

            await _serviceManager.Artist.UpdateArtist(artist, artistEntity);

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateArtistForGenreExistsAttribute))]
        [Authorize(Roles = "Administrator")]
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