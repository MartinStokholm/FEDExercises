import React from "react";
import Button from "./Button";
import Label from "./Label";
import Input from "./Input";
const Login = () => {
  const [email, setEmail] = React.useState("");
  const [password, setPassword] = React.useState("");
  const onLoginSubmit = () => {
    console.log("Login");
  };

  return (
    <div>
      <form>
        <Label text="Username:" input={<Input type="text" name="username" />} />
        <Label
          text="Password:"
          input={<Input type="password" name="password" />}
        />
        <Button onClick={onLoginSubmit()} text="Submit" />
      </form>
    </div>
  );
};

export default Login;
