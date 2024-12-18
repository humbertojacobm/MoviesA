using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int RatingValue { get; set; }
        public string VotersFullName { get; set; }
        public Movie Movie { get; set; }
    }
}
