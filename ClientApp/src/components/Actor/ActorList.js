import React from "react";
import Table from "react-bootstrap/Table";
import PropTypes from "prop-types";

const propTypes = {
  actors: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      Name: PropTypes.string.isRequired,
    })
  ).isRequired,
};

const ActorList = ({ actors }) => {
  return (
    <div className="mt-4">
      <Table striped bordered hover responsive>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {actors.map((actor) => (
            <tr key={actor.id}>
              <td>{actor.id}</td>
              <td>{actor.name}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

ActorList.propTypes = propTypes;

export { ActorList };
