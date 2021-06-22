using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class ArtistForCreationDto
    {
        [Required(ErrorMessage = "Artist name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Artist name is 30 characters.")]
        public string ArtistName { get; set; }
    }
}