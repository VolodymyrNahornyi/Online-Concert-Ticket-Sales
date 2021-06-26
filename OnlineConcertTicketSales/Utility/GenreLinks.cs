using Contracts;
using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineConcertTicketSales.Utility
{
    public class GenreLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<GenreDto> _dataShaper;

        public GenreLinks(LinkGenerator linkGenerator, IDataShaper<GenreDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }
        
        public LinkResponse TryGenerateLinks(IEnumerable<GenreDto> genresDto, 
            string fields, HttpContext httpContext)
        {
            var shapedGenres = ShapeData(genresDto, fields);
            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkedGenres(genresDto, fields, httpContext, 
                    shapedGenres); 
            return ReturnShapedGenres(shapedGenres);
        }
        private List<Entity> ShapeData(IEnumerable<GenreDto> genresDtos, string fields) 
            =>
                _dataShaper.ShapeData(genresDtos, fields)
                    .Select(e => e.Entity)
                    .ToList();

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", 
                StringComparison.InvariantCultureIgnoreCase);
        }
        private LinkResponse ReturnShapedGenres(List<Entity> shapedGenres) => new
            LinkResponse { ShapedEntities = shapedGenres };
        
        private LinkResponse ReturnLinkedGenres(IEnumerable<GenreDto> genresDto, 
            string fields, HttpContext httpContext, List<Entity> shapedGenres)
        {
            var genresDtoList = genresDto.ToList();
            for (var index = 0; index < genresDtoList.Count(); index++)
            {
                var genreLinks = CreateLinksForGenre(httpContext, 
                    genresDtoList[index].Id, fields);
                shapedGenres[index].Add("Links", genreLinks);
            }
            var genreCollection = new LinkCollectionWrapper<Entity>(shapedGenres);
            var linkedGenres = CreateLinksForGenres(httpContext, genreCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = linkedGenres };
        }
        
        private List<Link> CreateLinksForGenre(HttpContext httpContext, Guid id, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(httpContext, "GetGenre", 
                        values: new { id, fields }),
                    "self",
                    "GET"),
                new Link(_linkGenerator.GetUriByAction(httpContext, 
                        "DeleteGenre", values: new { id }),
                    "delete_genre",
                    "DELETE"),
                new Link(_linkGenerator.GetUriByAction(httpContext, 
                        "UpdateGenre", values: new { id }),
                    "update_genre",
                    "PUT")
            };
            return links;
        }
        private LinkCollectionWrapper<Entity> CreateLinksForGenres(HttpContext httpContext, 
            LinkCollectionWrapper<Entity> genresWrapper)
        {
            genresWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, 
                    "GetGenres", values: new { }),
                "self",
                "GET"));
            return genresWrapper;
        }


    }
}