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

            CreateMap<Model.Movie, DTO.Movie>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                                         .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                                         .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
                                         .ForMember(dest => dest.ActorNames, opt => opt.MapFrom(src => src.Actors.Select(a => a.Name)))
                                         .ReverseMap();

            CreateMap<Model.Actor, DTO.Actor>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                                         .ForMember(dest => dest.MovieTitles, opt => opt.MapFrom(src => src.Movies.Select(m => m.Title)))
                                         .ReverseMap();
        }
    }
}
