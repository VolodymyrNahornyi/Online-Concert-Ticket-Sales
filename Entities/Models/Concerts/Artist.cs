using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Concerts
{
    public class Artist
    {
        [Column("ArtistId")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Artist name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Artist Name is 60 characters.")]
        public string ArtistName { get; set; }
        
        [ForeignKey(nameof(Genre))]
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}