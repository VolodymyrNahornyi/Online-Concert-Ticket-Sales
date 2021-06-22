using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models.Concerts;
using Microsoft.AspNetCore.Mvc;
using OnlineConcertTicketSales.ModelBinders;

namespace OnlineConcertTicketSales.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public GenreController(IServiceManager serviceManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Genres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGenres()
        {
            var genres = _serviceManager.Genre.GetAllGenres(false);

            var genresDto = _mapper.Map<IEnumerable<GenreDto>>(genres);

            return Ok(genresDto);
        }

        /// <summary>
        /// Get Genre By Id
        /// </summary>
        /// <param name="id">Uniq ID for single genre</param>
        /// <returns></returns>
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

        /// <summary>
        /// Create New Genre
        /// </summary>
        /// <param name="genre">Genre For Creation Dto object [FromBody]</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateGenre([FromBody] GenreForCreationDto genre)
        {
            if (genre == null)
            {
                _logger.LogError("GenreForCreationDto object sent from client is null.");
                return BadRequest("GenreForCreationDto object is null");
            }

            var genreEntity = _mapper.Map<Genre>(genre);
            
            _serviceManager.Genre.CreateGenre(genreEntity);
            _serviceManager.Save();

            var genreToReturn = _mapper.Map<GenreDto>(genreEntity);

            return CreatedAtRoute("GenreById", new {id = genreToReturn.Id}, genreToReturn);
        }

        /// <summary>
        /// Get Genre Collection By Ids Collection
        /// </summary>
        /// <param name="Ids">Ids Collection of Genres</param>
        /// <returns></returns>
        [HttpGet("collection/({Ids})", Name = "GenreCollection")]
        public IActionResult GetGenreCollection([ModelBinder(BinderType = 
            typeof(ArrayModelBinder))]IEnumerable<Guid> Ids)
        {
            if (Ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }

            var genreEntities = _serviceManager.Genre.GetGenresByIds(Ids, false);

            if (Ids.Count() != genreEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NoContent();
            }

            var genreToReturn = _mapper.Map<IEnumerable<GenreDto>>(genreEntities);
            return Ok(genreToReturn);
        }

        /// <summary>
        /// Create Genre Collection
        /// </summary>
        /// <param name="genreCollection">Genre Collection [FromBody]</param>
        /// <returns></returns>
        [HttpPost("collection")]
        public IActionResult CreateGenreCollection([FromBody] IEnumerable<GenreForCreationDto> genreCollection)
        {
            if (genreCollection == null)
            {
                _logger.LogError("GenreForCreationDto collection object sent from client is null.");
                return BadRequest("GenreForCreationDto collection object is null");
            }

            var genreEntities = _mapper.Map<IEnumerable<Genre>>(genreCollection);

            foreach (var genreEntity in genreEntities)
            {
                _serviceManager.Genre.CreateGenre(genreEntity);
            }
            _serviceManager.Save();

            var genreCollectionToReturn = _mapper.Map<IEnumerable<GenreDto>>(genreEntities);
            var ids = string.Join(",", genreCollectionToReturn.Select(c => c.Id));
            
            return CreatedAtRoute("GenreCollection", new { ids }, genreCollectionToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(Guid id)
        {
            var genre = _serviceManager.Genre.GetGenre(id, false);
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            
            _serviceManager.Genre.DeleteGenre(genre);
            _serviceManager.Save();

            return NoContent();
        }
        
    }
}