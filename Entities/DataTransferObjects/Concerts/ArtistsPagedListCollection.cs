using System.Collections.Generic;
using Entities.RequestFeatures;

namespace Entities.DataTransferObjects
{
    public class ArtistsPagedListCollection
    {
        public MetaData MetaData { get; set; }
        public IEnumerable<ArtistDto> ArtistsDto { get; set; } = new List<ArtistDto>();
        
        public ArtistsPagedListCollection()
        {
            
        }
    }
}