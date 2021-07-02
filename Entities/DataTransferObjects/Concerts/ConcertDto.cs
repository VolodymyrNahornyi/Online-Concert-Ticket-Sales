using System;

namespace Entities.DataTransferObjects
{
    public class ConcertDto
    {
        public Guid Id { get; set; }
        public string ConcertName { get; set; }
        public DateTime Date { get; set; }
    }
}