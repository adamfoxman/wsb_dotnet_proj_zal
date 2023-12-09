using System;
using AutoMapper;
using proj_zal.Models;
using proj_zal.ViewModels;

namespace YourNamespace.Mappers
{
    public class AlbumMapper
    {
        private readonly IMapper _mapper;

        public AlbumMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Album, AlbumViewModel>()
                    .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Artist.ArtistId));
            });

            _mapper = config.CreateMapper();
        }

        public AlbumViewModel MapToViewModel(Album album)
        {
            return _mapper.Map<AlbumViewModel>(album);
        }
    }
}
