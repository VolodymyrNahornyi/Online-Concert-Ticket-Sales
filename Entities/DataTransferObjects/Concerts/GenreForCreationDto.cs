using System;
using System.Collections.Generic;
using Entities.Models.Concerts;

namespace Entities.DataTransferObjects
{
    public class GenreForCreationDto
    {
        public GenreName GenreName { get; set; }
        
        public IEnumerable<ArtistForCreationDto> Artists { get; set; }
    }
}