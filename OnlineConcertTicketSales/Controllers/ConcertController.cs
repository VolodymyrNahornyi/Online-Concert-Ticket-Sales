﻿using System;
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
        /// <returns>Response status 200 Ok</returns>
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

        /// <summary>
        /// Get Single concert for single artist for concrete genre
        /// </summary>
        /// <param name="genreId">Genre's Id</param>
        /// <param name="artistId">Artist's Id</param>
        /// <param name="id">Concert's Id</param>
        /// <returns>Response status 200 Ok</returns>
        [HttpGet("{id}", Name = "GetConcertForArtistForGenre")]
        public async Task<IActionResult> GetConcertForArtistForGenre(Guid genreId, Guid artistId, Guid id)
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

            var concertFromDb = await _serviceManager.Concert.GetConcertAsync(genreId, artistId, id, false);
            if (concertFromDb == null)
            {
                _logger.LogInfo($"Concert with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var concertDto = _mapper.Map<ConcertDto>(concertFromDb);

            return Ok(concertDto);
        }

        /// <summary>
        /// Create New Concert for concrete artist and concrete genre
        /// </summary>
        /// <param name="genreId">Genre's Id</param>
        /// <param name="artistId">Artist's Id</param>
        /// <param name="concert">Concert object</param>
        /// <returns>Response status 201 Ok. New Concert object</returns>
        [HttpPost]
        public async Task<IActionResult> CreateConcertForArtistForGenre(Guid genreId, Guid artistId, [FromBody] ConcertForCreationDto concert)
        {
            if(concert == null) 
            { 
                _logger.LogError("ConcertForCreationDto object sent from client is null."); 
                return BadRequest("ConcertForCreationDto object is null"); 
            }
            
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

            var concertEntity = _mapper.Map<Concert>(concert);
            _serviceManager.Concert.CreateConcert(artistId, concertEntity);
            await _serviceManager.SaveAsync();

            var concertToReturn = _mapper.Map<ConcertDto>(concertEntity);
            
            return CreatedAtRoute("GetConcertForArtistForGenre", new {genreId, artistId, id = concertToReturn.Id}, concertToReturn);
        }

        /// <summary>
        /// Delete Single concert for single artist for concrete genre
        /// </summary>
        /// <param name="genreId">Genre's Id</param>
        /// <param name="artistId">Artist's Id</param>
        /// <param name="id">Concert's Id</param>
        /// <returns>Response status 204 NoContent</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcertForArtistForGenre(Guid genreId, Guid artistId, Guid id)
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

            var concertForArtistForGenre = await _serviceManager.Concert.GetConcertAsync(genreId, artistId, id, false);
            if (concertForArtistForGenre == null)
            {
                _logger.LogInfo($"Concert with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            
            _serviceManager.Concert.DeleteConcert(concertForArtistForGenre);
            await _serviceManager.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// Full Update the Concert object by Id 
        /// </summary>
        /// <param name="genreId">Genre's Id</param>
        /// <param name="artistId">Artist's Id</param>
        /// <param name="id">Concert's Id</param>
        /// <param name="concert">Update Concert object</param>
        /// <returns>Response 204 NoContent</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConcertForArtistForGenre(Guid genreId, Guid artistId, Guid id,
            [FromBody] ConcertForUpdateDto concert)
        {
            if(concert == null) 
            { 
                _logger.LogError("ConcertForUpdateDto object sent from client is null."); 
                return BadRequest("ConcertForUpdateDto object is null"); 
            }
            
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

            var concertEntity = await _serviceManager.Concert.GetConcertAsync(genreId, artistId, id, true);
            if (concertEntity == null)
            {
                _logger.LogInfo($"Concert with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(concert, concertEntity);
            _serviceManager.SaveAsync();

            return NoContent();
        }
        
    }
}