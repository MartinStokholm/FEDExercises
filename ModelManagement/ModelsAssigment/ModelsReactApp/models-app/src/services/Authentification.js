import axios from "axios";

const API_URL = "http://localhost:7181/api/account/";

const login = (email, password) => {
  return axios
    .post(API_URL + "login", {
      email,
      password,
    })
    .then((response) => {
      if (response.data.jwt) {
        localStorage.setItem("jwt", JSON.stringify(response.data));
      }
      return response.data;
    });
};

const logout = () => {
  localStorage.removeItem("jwt");
};

const AuthService = {
  login,
  logout,
};

export default AuthService;
