using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.RequestFeatures
{
    public class ConcertParameters : RequestParameters
    {
        public DateTime StartDate { get; set; } //= DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public bool ValidDateRange => EndDate > StartDate;
        
        public ConcertParameters()
        {
            OrderBy = "concertName";
        }
        
        public string SearchTerm { get; set; }
    }
    

}