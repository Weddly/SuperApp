import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:5001', // Backend base URL
  withCredentials: false,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiClient;
