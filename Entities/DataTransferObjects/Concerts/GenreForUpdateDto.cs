using System.Collections.Generic;
using Entities.Models.Concerts;

namespace Entities.DataTransferObjects
{
    public class GenreForUpdateDto
    {
        public GenreName GenreName { get; set; }
        
        public IEnumerable<ArtistForCreationDto> Artists { get; set; }
    }
}