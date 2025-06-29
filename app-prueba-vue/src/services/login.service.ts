import axios from 'axios';

const API_URL = "https://localhost:7155/api/Auth/";
const getAuthHeader = () => {
  return {
    'Access-Control-Allow-Origin': '*',
    Accept: 'application/json, text/plain, */*', "loading": true
  };
};

class LoginService {
    login(Usuario: string, Contrasena: string) {
        return  axios.post(`${API_URL}login`, { Usuario, Contrasena }, { headers: getAuthHeader()});
    }
}

export default new LoginService();