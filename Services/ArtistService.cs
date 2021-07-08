using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models.Concerts;
using Entities.RequestFeatures;

namespace Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ArtistService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        
        public async Task<ArtistsPagedListCollection> GetArtistsAsync(Guid genreId, ArtistParameters artistParameters, bool trackChanges)
        {
            var artists = await _repositoryManager.Artist.GetArtistsAsync(genreId, artistParameters, trackChanges);
            var artistsDto = _mapper.Map<IEnumerable<ArtistDto>>(artists);
            var artistsCol = new ArtistsPagedListCollection {ArtistsDto = artistsDto, MetaData = artists.MetaData};
            return artistsCol;
        }

        // public async Task<PagedList<Artist>> GetArtistsAsync(Guid genreId, ArtistParameters artistParameters, bool trackChanges)
        // {
        //     return await _repositoryManager.Artist.GetArtistsAsync(genreId, artistParameters, trackChanges);
        // }

        public async Task<ArtistDto> GetArtistAsync(Guid genreId, Guid id, bool trackChanges)
        {
            var artist = await _repositoryManager.Artist.GetArtistAsync(genreId, id, trackChanges);
            if (artist != null)
            {
                var artistDto = _mapper.Map<ArtistDto>(artist);
                return artistDto;
            }
            return null;
        }

        public void CreateArtist(Guid genreId, Artist artist)
        {
            _repositoryManager.Artist.CreateArtist(genreId, artist);
        }

        public void DeleteArtist(Artist artist)
        {
            _repositoryManager.Artist.DeleteArtist(artist);
        }
    }
}