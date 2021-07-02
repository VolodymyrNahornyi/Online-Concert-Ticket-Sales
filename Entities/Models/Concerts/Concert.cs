using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Concerts
{
    public class Concert
    {
        [Column("ConcertId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Concert name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Concert Name is 60 characters.")]
        public string ConcertName { get; set; }
        
        [ForeignKey(nameof(Artist))]
        public Guid ArtistId { get; set; }

        public Artist Artist { get; set; }
        
        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm:ss}")]
        public DateTime Date { get; set; }
    }
}