using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models.Concerts;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineConcertTicketSales.ActionFilters;
using OnlineConcertTicketSales.Utility;

namespace OnlineConcertTicketSales.Controllers
{
    [Route("api/genres/{genreId}/artists/{artistId}/concerts")]
    [ApiController]
    public class ConcertController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ConcertController(IServiceManager serviceManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all concerts for single artist for concrete genre
        /// </summary>
        /// <param name="genreId">Genre's Id</param>
        /// <param name="artistId">Artist's Id</param>
        /// <param name="concertParameters">Concert's Request parameter</param>
        /// <returns></returns>
        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetConcertsForArtistForGenreAsync(Guid genreId, Guid artistId, [FromQuery] ConcertParameters concertParameters)
        {
            var genre = await _serviceManager.Genre.GetGenreAsync(genreId, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                return NotFound();
            }
            
            var artist = await _serviceManager.Artist.GetArtistAsync(genreId, artistId, false);
            if (artist == null)
            {
                _logger.LogInfo($"Artist with id: {artistId} doesn't exist in the database.");
                return NotFound();
            }

            var concertsFromDb =
                await _serviceManager.Concert.GetConcertsAsync(genreId, artistId, concertParameters, false);
            
            //Add Pagination MetaData to the Response
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(concertsFromDb.MetaData));
            
            var concertDto = _mapper.Map<IEnumerable<ConcertDto>>(concertsFromDb);

            return Ok(concertDto);
        }
    }
}