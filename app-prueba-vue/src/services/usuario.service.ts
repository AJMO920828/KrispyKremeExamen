import axios from 'axios';

const API_URL = "https://localhost:7155/api/Auth/";
const getAuthHeader = () => {
  const token = localStorage.getItem("token") || ""; // Recupera el token de localStorage
  return {
    'Access-Control-Allow-Origin': '*',
    Accept: 'application/json, text/plain, */*',
    'Authorization': `Bearer ${token}`,
    "loading": true
  };
};

export default {
  async obtenerUsuarios() {
    const response = await axios.get(`${API_URL}usuarios`, { headers: getAuthHeader() });
    return response;
  },
  async crearUsuario(usuario: any) {
    const response = await axios.post(`${API_URL}registrarUsuario`, usuario, { headers: getAuthHeader() });
    return response;
  }
};