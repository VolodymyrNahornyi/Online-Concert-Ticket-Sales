using System;
using Entities.Models.Concerts;

namespace Entities.DataTransferObjects
{
    public class GenreDto
    {
        public Guid Id { get; set; }
        public GenreName GenreName { get; set; }
    }
}