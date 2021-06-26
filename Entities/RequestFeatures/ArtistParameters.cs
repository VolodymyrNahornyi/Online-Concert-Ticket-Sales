using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.RequestFeatures
{
    public class ArtistParameters : RequestParameters
    {
        public ArtistParameters()
        {
            OrderBy = "artistName";
        }

        public string SearchTerm { get; set; }
        
    }
    

}