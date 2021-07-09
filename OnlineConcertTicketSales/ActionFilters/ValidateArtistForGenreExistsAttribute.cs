using System;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineConcertTicketSales.ActionFilters
{
    public class ValidateArtistForGenreExistsAttribute : IAsyncActionFilter
    {
        
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        
        public ValidateArtistForGenreExistsAttribute(IServiceManager serviceManager, ILoggerManager logger)
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

            var id = (Guid)context.ActionArguments["id"];
            
            var artistForGenre = await _serviceManager.Artist.GetArtistForValidationAsync(genreId, id, trackChanges);

            if (artistForGenre == null)
            {
                _logger.LogInfo($"Artist with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("artistForGenre", artistForGenre);
                await next();

            }
        }
    }
}