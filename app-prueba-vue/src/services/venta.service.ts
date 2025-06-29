
import axios from "axios";

const API_URL = "https://localhost:7155/api/";
const getAuthHeader = () => {
  const token = localStorage.getItem("token") || ""; // Recupera el token de localStorage
  return {
    'Access-Control-Allow-Origin': '*',
    Accept: 'application/json, text/plain, */*',
    'Authorization': `Bearer ${token}`,
    "loading": true
  };
};

class VentaService {
  async getVentas() {
    const response = await axios.get(`${API_URL}ventas`,{ headers: getAuthHeader() });
    return response; 
  }
  async guardarVenta(venta: any) {
    const response = await axios.post(`${API_URL}ventas`, venta ,{ headers: getAuthHeader() });
    return response; 
  }
}
export default new VentaService();



