import React, { useState, useEffect } from "react";
import { MovieList } from "../../components";
import {
  fetchMovies,
  createMovie,
  updateMovie,
  deleteMovie,
} from "../../apis/moviesApi";
import { Button, Modal, Form } from "react-bootstrap";

const MovieContainer = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [newMovie, setNewMovie] = useState({
    name: "",
    genre: "",
    releaseYear: new Date().getFullYear(),
  });
  const [editingMovie, setEditingMovie] = useState(null);

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

  const handleAddMovie = async () => {
    try {
      if (editingMovie) {
        const updatedMovies = movies.map((movie) =>
          movie.id === editingMovie.id
            ? { ...editingMovie, ...newMovie }
            : movie
        );
        await updateMovie(newMovie);
        setMovies(updatedMovies);
        setEditingMovie(null);
      } else {
        const createdMovie = await createMovie(newMovie);
        setMovies([...movies, createdMovie]);
      }
      setShowModal(false);
    } catch (err) {
      setError(err.message);
    }
    setNewMovie({
      name: "",
      genre: "",
      releaseYear: new Date().getFullYear(),
    });
  };

  const handleEditMovie = (movie) => {
    setEditingMovie(movie);
    setNewMovie(movie);
    setShowModal(true);
  };

  const handleDeleteMovie = async (movieId) => {
    try {
      await deleteMovie(movieId);
      setMovies(movies.filter((movie) => movie.id !== movieId));
    } catch (err) {
      setError(err.message);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setNewMovie((prevMovie) => ({
      ...prevMovie,
      [name]: value,
    }));
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div>
      <Button onClick={() => setShowModal(true)}>Add Movie</Button>
      <MovieList
        movies={movies}
        onEdit={handleEditMovie}
        onDelete={handleDeleteMovie}
      />

      <Modal show={showModal} onHide={() => setShowModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>
            {editingMovie ? "Edit Movie" : "Add New Movie"}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formMovieName">
              <Form.Label>Name</Form.Label>
              <Form.Control
                type="text"
                name="name"
                value={newMovie.name}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group controlId="formMovieGenre">
              <Form.Label>Genre</Form.Label>
              <Form.Control
                type="text"
                name="genre"
                value={newMovie.genre}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group controlId="formMovieReleaseYear">
              <Form.Label>Release Year</Form.Label>
              <Form.Control
                type="number"
                name="releaseYear"
                value={newMovie.releaseYear}
                onChange={handleChange}
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowModal(false)}>
            Close
          </Button>
          <Button variant="primary" onClick={handleAddMovie}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default MovieContainer;
