import axios from 'axios';
import authHeader from './auth-header';

const API_URL = 'http://localhost:5135/api/Persona/';

class UserService {
  getPublicContent() {
    return axios.get(API_URL + 'select', { headers: authHeader() });
  }

  getUserBoard() {
    return axios.get(API_URL + 'user', { headers: authHeader() });
  }

  getModeratorBoard() {
    return axios.get(API_URL + 'mod', { headers: authHeader() });
  }

  getAdminBoard() {
    return axios.get(API_URL + 'admin', { headers: authHeader() });
  }
}

export default new UserService();
