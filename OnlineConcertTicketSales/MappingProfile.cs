using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models.Concerts;

namespace OnlineConcertTicketSales
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<Artist, ArtistDto>();
            CreateMap<GenreForCreationDto, Genre>();
            CreateMap<ArtistForCreationDto, Artist>();
            CreateMap<ArtistForUpdateDto, Artist>().ReverseMap();
            CreateMap<GenreForUpdateDto, Genre>();
        }
    }
}