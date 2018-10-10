using System;
using AutoMapper;
using Google.Apis.Books.v1.Data;
using GoogleBooksApi.Controllers;

namespace GoogleBooksApi.Test.Mappings
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Book, Volume.VolumeInfoData>()
                .ForMember(dest => dest.ImageLinks.Thumbnail,
                    opt => opt.MapFrom(src => src.Image))
                .ReverseMap()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src => src.ImageLinks.Thumbnail));
        }

    }
}
