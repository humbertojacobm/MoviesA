import React from "react";
import Table from "react-bootstrap/Table";
import PropTypes from "prop-types";

const propTypes = {
  movies: PropTypes.object.isRequired,
};

const MovieList = ({ movies }) => {
  return (
    <div className="mt-4">
      <Table striped bordered hover responsive>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Genre</th>
            <th>Release Year</th>
          </tr>
        </thead>
        <tbody>
          {movies.map((movie) => (
            <tr key={movie.id}>
              <td>{movie.id}</td>
              <td>{movie.name}</td>
              <td>{movie.genre}</td>
              <td>{movie.releaseYear}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

MovieList.propTypes = propTypes;

export { MovieList };
