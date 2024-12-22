import React from "react";
import { Modal, Button } from "react-bootstrap";
import PropTypes from "prop-types";

const DeleteConfirmationModal = ({ onHide, movieToDelete, handleDelete }) => {
  return (
    <>
      <Modal.Header closeButton>
        <Modal.Title>Confirm Delete</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        Are you sure you want to delete the movie{" "}
        {movieToDelete && `"${movieToDelete.name}"`}?
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onHide}>
          Cancel
        </Button>
        <Button variant="danger" onClick={handleDelete}>
          Delete
        </Button>
      </Modal.Footer>
    </>
  );
};

DeleteConfirmationModal.propTypes = {
  onHide: PropTypes.func.isRequired,
  movieToDelete: PropTypes.object,
  handleDelete: PropTypes.func.isRequired,
};

export { DeleteConfirmationModal };
