using System;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineConcertTicketSales.ActionFilters
{
    public class ValidateGenreExistsAttribute : IAsyncActionFilter
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;

        public ValidateGenreExistsAttribute(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (Guid)context.ActionArguments["id"];
            _logger.LogDebug($"id: {id}");
            
            var genre = await _serviceManager.Genre.GetGenreAsync(id, trackChanges);

            if (genre == null)
            {
                _logger.LogInfo($"Genre with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("genre", genre);
                await next();

            }
        }
    }
}