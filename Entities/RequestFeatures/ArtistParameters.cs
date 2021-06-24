using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string OrderBy { get; set; }
        public string Fields { get; set; }
    }
    
    public class ArtistParameters : RequestParameters
    {
        public ArtistParameters()
        {
            OrderBy = "artistName";
        }

        public string SearchTerm { get; set; }
        
    }

}