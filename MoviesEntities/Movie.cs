namespace Movies.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
