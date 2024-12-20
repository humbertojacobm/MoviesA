import React, { useState, useEffect } from "react";
import { MovieList } from "../../components";
import { fetchMovies } from "../../apis/moviesApi";

const MovieContainer = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const loadMovies = async () => {
      try {
        const data = await fetchMovies();
        setMovies(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    loadMovies();
  }, []);

  const handleAddMovie = () => {
    // Logic to add a new movie
    const newMovie = {
      id: movies.length + 1,
      name: "New Movie",
      genre: "Genre",
      releaseYear: new Date().getFullYear(),
    };
    setMovies([...movies, newMovie]);
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div>
      <button onClick={handleAddMovie}>Add Movie</button>
      <MovieList movies={movies} />
    </div>
  );
};

export default MovieContainer;
