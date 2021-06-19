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
        }
    }
}