using System;
using AutoMapper;
using Google.Apis.Books.v1.Data;
using GoogleBooksApi.ClientApp.Models;
using GoogleBooksApi.Controllers;

namespace GoogleBooksApi.Test.Mappings
{
    public class MappingUnitTestConfiguration : Profile
    {
        public MappingUnitTestConfiguration()
        {
            CreateMap<Book, Volume.VolumeInfoData>()
                .ForPath(dest => dest.ImageLinks.Thumbnail,
                    opt => opt.MapFrom(src => src.Image))
                .ReverseMap()
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src => src.ImageLinks.Thumbnail));
        }

    }
}
