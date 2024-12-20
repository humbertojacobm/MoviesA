import React, { useState, useEffect } from "react";
import { ActorList } from "../../components";
import { fetchActors } from "../../apis/actorsApi";

const ActorContainer = () => {
  const [actors, setActors] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const loadActors = async () => {
      try {
        const data = await fetchActors();
        setActors(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    loadActors();
  }, []);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return <ActorList actors={actors} />;
};

export default ActorContainer;
