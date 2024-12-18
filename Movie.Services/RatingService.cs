using AutoMapper;
using Movies.DTOs;
using Movies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RatingDTO>> GetRatingsByMovieIdAsync(int movieId)
        {
            var ratings = await _ratingRepository.GetRatingsByMovieIdAsync(movieId);
            return _mapper.Map<IEnumerable<RatingDTO>>(ratings);
        }
    }
}
