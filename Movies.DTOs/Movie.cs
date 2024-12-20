﻿namespace Movies.DTOs
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public List<string> ActorNames { get; set; }
    }
}
