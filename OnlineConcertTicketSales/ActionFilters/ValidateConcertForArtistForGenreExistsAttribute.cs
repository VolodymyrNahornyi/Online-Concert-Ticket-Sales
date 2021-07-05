using System;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineConcertTicketSales.ActionFilters
{
    public class ValidateConcertForArtistForGenreExistsAttribute : IAsyncActionFilter
    {
        
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        
        public ValidateConcertForArtistForGenreExistsAttribute(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = method.Equals("PUT") || method.Equals("PATCH") ? true : false;
            
            var genreId = (Guid)context.ActionArguments["genreId"];
            var genre = await _serviceManager.Genre.GetGenreAsync(genreId, false);
            
            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {genreId} doesn't exist in the database.");
                context.Result = new NotFoundResult();
                return;
            }

            var artistId = (Guid)context.ActionArguments["artistId"];
            var artist = await _serviceManager.Artist.GetArtistAsync(genreId, artistId, false);
            
            if (artist == null)
            {
                _logger.LogInfo($"Artist with id: {artistId} doesn't exist in the database.");
                context.Result = new NotFoundResult();
                return;
            }

            var id = (Guid)context.ActionArguments["id"];
            var concertForArtistForGenre = await _serviceManager.Concert.GetConcertAsync(genreId, artistId, id, trackChanges);
            
            if (concertForArtistForGenre == null)
            {
                _logger.LogInfo($"Concert with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("concertForArtistForGenre", concertForArtistForGenre);
                await next();

            }
        }
    }
}