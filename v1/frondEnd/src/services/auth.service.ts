import axios from "axios";

const API_URL = "http://localhost:5135/api/User/";

class AuthService {
  login(userName: string, password: string) {
    return axios
      .post(API_URL + "Generate/Token", {
        userName,
        password
      })
      .then(response => {
        if (response.data.isSuccess) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }

        return response.data;
      });
  }

  logout() {
    localStorage.removeItem("user");
  }

  register(userName: string, email: string, password: string, image: string) {
    let state: number = 1
    return axios.post(API_URL + "Register", {
      userName,
      email,
      password,
      image,
      state
    });
  }

  getCurrentUser() {
    const userStr = localStorage.getItem("user");
    if (userStr) return JSON.parse(userStr);

    return null;
  }
}

export default new AuthService();
