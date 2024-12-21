import axios from "axios";

const API_BASE_URL = "http://localhost:5000/api";
const API_KEY = "oI64MNMMKuSRfdwrdfvL1ptB6lHOCgpS";

export const fetchMovies = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/movies`);
    return response.data;
  } catch (error) {
    console.error("Error fetching movies:", error);
    throw error;
  }
};

export const createMovie = async (movie) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/movies`, movie, {
      headers: {
        "Content-Type": "application/json",
        "X-API-KEY": API_KEY,
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error creating movie:", error);
    throw error;
  }
};
