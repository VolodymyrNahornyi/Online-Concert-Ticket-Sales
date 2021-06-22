using System.Collections.Generic;
using Entities.Models.Concerts;
using Entities.ValidationAttributes;

namespace Entities.DataTransferObjects
{
    public abstract class GenreForManipulationDto
    {
        [RequiredEnumField(ErrorMessage = "Genre name is a required field!")]
        public GenreName GenreName { get; set; }
        
        
        public IEnumerable<ArtistForCreationDto> Artists { get; set; }
    }
}