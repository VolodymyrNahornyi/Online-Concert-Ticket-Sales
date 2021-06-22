using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Models.Concerts;
using Entities.ValidationAttributes;

namespace Entities.DataTransferObjects
{
    public class GenreForCreationDto
    {
        [RequiredEnumField(ErrorMessage = "Genre name is a required field!")]
        public GenreName GenreName { get; set; }
        
        
        public IEnumerable<ArtistForCreationDto> Artists { get; set; }
    }
}