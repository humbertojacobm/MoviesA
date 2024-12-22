import React, { useState, useEffect } from "react";
import {
  MovieList,
  MovieCreationEditionModal,
  DeleteConfirmationModal,
} from "../../components";
import {
  fetchMovies,
  createMovie,
  updateMovie,
  deleteMovie,
} from "../../apis/moviesApi";
import { Button, Modal } from "react-bootstrap";

const MovieContainer = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [newMovie, setNewMovie] = useState({
    name: "",
    genre: "",
    releaseYear: new Date().getFullYear(),
  });
  const [editingMovie, setEditingMovie] = useState(null);
  const [movieToDelete, setMovieToDelete] = useState(null);

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

  const handleDeleteMovie = async () => {
    try {
      await deleteMovie(movieToDelete.id);
      setMovies(movies.filter((movie) => movie.id !== movieToDelete.id));
      setShowDeleteModal(false);
      setMovieToDelete(null);
    } catch (err) {
      setError(err.message);
    }
  };

  const handleShowDeleteModal = (movie) => {
    setMovieToDelete(movie);
    setShowDeleteModal(true);
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
        onDelete={handleShowDeleteModal}
      />

      <Modal show={showModal} onHide={() => setShowModal(false)}>
        <MovieCreationEditionModal
          show={showModal}
          onHide={() => setShowModal(false)}
          editingMovie={editingMovie}
          newMovie={newMovie}
          handleChange={handleChange}
          handleSave={handleAddMovie}
        />
      </Modal>

      <Modal show={showDeleteModal} onHide={() => setShowDeleteModal(false)}>
        <DeleteConfirmationModal
          show={showDeleteModal}
          onHide={() => setShowDeleteModal(false)}
          movieToDelete={movieToDelete}
          handleDelete={handleDeleteMovie}
        />
      </Modal>
    </div>
  );
};

export default MovieContainer;
