using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public abstract class ConcertForManipulationDto
    {
        [Required(ErrorMessage = "Concert name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Concert name is 30 characters.")]
        public string ConcertName { get; set; }
        
        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm:ss}")]
        public DateTime? Date { get; set; }
    }
}