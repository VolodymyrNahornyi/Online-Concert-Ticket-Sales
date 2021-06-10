using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Concerts
{
    public class Genre
    {
        [Column("GenreId")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Genre name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Genre Name is 30 characters.")]
        public string GenreName { get; set; }
    }
}