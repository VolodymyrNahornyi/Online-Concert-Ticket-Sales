using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class ArtistForUpdateDto : ArtistForManipulationDto
    {
        public IEnumerable<ConcertForCreationDto> Concerts { get; set; }
    }
}