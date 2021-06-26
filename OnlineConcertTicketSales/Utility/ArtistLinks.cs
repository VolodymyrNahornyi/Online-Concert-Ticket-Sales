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
    public class ArtistLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<ArtistDto> _dataShaper;

        public ArtistLinks(LinkGenerator linkGenerator, IDataShaper<ArtistDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }
        
        public LinkResponse TryGenerateLinks(IEnumerable<ArtistDto> artistsDto, 
            string fields, Guid genreId, HttpContext httpContext)
        {
            var shapedArtists = ShapeData(artistsDto, fields);
            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkedArtists(artistsDto, fields, genreId, httpContext, 
                    shapedArtists); 
            return ReturnShapedArtists(shapedArtists);
        }
        private List<Entity> ShapeData(IEnumerable<ArtistDto> artistsDto, string fields) 
            =>
                _dataShaper.ShapeData(artistsDto, fields)
                    .Select(e => e.Entity)
                    .ToList();

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", 
                StringComparison.InvariantCultureIgnoreCase);
        }
        private LinkResponse ReturnShapedArtists(List<Entity> shapedArtists) => new
            LinkResponse { ShapedEntities = shapedArtists };
        
        private LinkResponse ReturnLinkedArtists(IEnumerable<ArtistDto> artistsDto, 
            string fields, Guid genreId, HttpContext httpContext, List<Entity> shapedArtists)
        {
            var artistsDtoList = artistsDto.ToList();
            for (var index = 0; index < artistsDtoList.Count(); index++)
            {
                var artistLinks = CreateLinksForArtist(httpContext, genreId, 
                    artistsDtoList[index].Id, fields);
                shapedArtists[index].Add("Links", artistLinks);
            }
            var artistCollection = new LinkCollectionWrapper<Entity>(shapedArtists);
            var linkedEmployees = CreateLinksForArtists(httpContext, artistCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = linkedEmployees };
        }
        
        private List<Link> CreateLinksForArtist(HttpContext httpContext, Guid genreId, 
            Guid id, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(httpContext, "GetArtistForGenre", 
                        values: new { genreId, id, fields }),
                    "self",
                    "GET"),
                new Link(_linkGenerator.GetUriByAction(httpContext, 
                        "DeleteArtistForGenre", values: new { genreId, id }),
                    "delete_artist",
                    "DELETE"),
                new Link(_linkGenerator.GetUriByAction(httpContext, 
                        "UpdateArtistForGenre", values: new { genreId, id }),
                    "update_artist",
                    "PUT"), 
                new Link(_linkGenerator.GetUriByAction(httpContext, 
                "PartiallyUpdateArtistForGenre", values: new { genreId, id }),
                "partially_update_artist",
                "PATCH")
            };
            return links;
        }
        private LinkCollectionWrapper<Entity> CreateLinksForArtists(HttpContext httpContext, 
            LinkCollectionWrapper<Entity> artistsWrapper)
        {
            artistsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, 
                    "GetArtistsForGenreAsync", values: new { }),
                "self",
                "GET"));
            return artistsWrapper;
        }


    }
}