using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Movies.DTOs;
using Model = Movies.Model;

namespace Movies.Services
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<DTO.Movie, Model.Movie>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                                         .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                                         .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
                                         .ReverseMap();
            CreateMap<DTO.Actor, Model.Actor>().ReverseMap();
        }
    }
}
