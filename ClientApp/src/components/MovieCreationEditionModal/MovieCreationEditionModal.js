import React from "react";
import { Modal, Button, Form } from "react-bootstrap";
import PropTypes from "prop-types";

const MovieCreationEditionModal = ({
  onHide,
  editingMovie,
  newMovie,
  handleChange,
  handleSave,
}) => {
  return (
    <>
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
        <Button variant="secondary" onClick={onHide}>
          Close
        </Button>
        <Button variant="primary" onClick={handleSave}>
          Save Changes
        </Button>
      </Modal.Footer>
    </>
  );
};

MovieCreationEditionModal.propTypes = {
  onHide: PropTypes.func.isRequired,
  editingMovie: PropTypes.object,
  newMovie: PropTypes.object.isRequired,
  handleChange: PropTypes.func.isRequired,
  handleSave: PropTypes.func.isRequired,
};

export { MovieCreationEditionModal };
