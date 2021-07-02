using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.RequestFeatures
{
    public class ConcertParameters : RequestParameters
    {
        public ConcertParameters()
        {
            OrderBy = "concertName";
        }
    }
    

}