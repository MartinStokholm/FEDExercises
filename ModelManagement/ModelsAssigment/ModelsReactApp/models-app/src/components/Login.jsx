import React, { useState } from "react";
import Button from "./utils/Button";
import Label from "./utils/Label";
import Input from "./utils/Input";
import Heading from "./utils/Heading";
import AuthService from "../services/Authentification";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const onChangeEmail = (e) => {
    const email = e.target.value;
    setEmail(email);
  };

  const onChangePassword = (e) => {
    const password = e.target.value;
    setPassword(password);
  };

  const handleLogin = (e) => {
    AuthService.login(email, password).then(
      () => {
        console.log(email, password);
        window.location.reload();
      },
      (error) => {
        const resMessage =
          (error.response &&
            error.response.data &&
            error.response.data.message) ||
          error.message ||
          error.toString();

        alert(resMessage);
      }
    );
  };

  return (
    <div>
      <Heading text="Login" />
      <div className="flex justify-start">
        <form
          onSubmit={handleLogin}
          className="flex flex-col items-start bg-white"
        >
          <Label text="Email:" />
          <Input
            type="email"
            value={email}
            onChange={onChangeEmail}
            name="email"
          />
          <Label text="Password:" />
          <Input
            type="password"
            value={password}
            onChange={onChangePassword}
            name="password"
          />
          <Button type="submit" text="Submit" />
        </form>
      </div>
    </div>
  );
};

export default Login;
