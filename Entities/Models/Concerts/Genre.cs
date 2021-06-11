using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Concerts
{
    public enum GenreName
    {
        Country,
        Electronic,
        Funk,
        HipHop,
        Jazz,
        Latin,
        Pop,
        Punk,
        Reggae,
        Rock,
        RandB,
        Polka
    }
    
    public class Genre
    {
        [Column("GenreId")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Genre name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Genre Name is 30 characters.")]
        public GenreName GenreName { get; set; }
        
        public ICollection<Artist> Artists { get; set; }
    }
}