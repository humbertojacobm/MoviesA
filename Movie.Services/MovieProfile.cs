using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Movies.DTOs;
using Model = MoviesEntities;

namespace Movie.Services
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<DTO.Movie, Model.Movie>().ReverseMap();
        }
    }
}
