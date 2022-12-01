import React from "react";
import Button from "./utils/Button";
import Label from "./utils/Label";
import Input from "./utils/Input";
import Heading from "./utils/Heading";

const CreateManager = () => {
  return (
    <div className="mx-2">
      <Heading text="Create Manager" />
      <div className="flex justify-start">
        <form className="flex flex-col items-end bg-white">
          <Label
            text="First name:"
            input={<Input type="text" name="firstName" />}
          />
          <Label
            text="Last name:"
            input={<Input type="text" name="lastName" />}
          />
          <Label text="Email:" input={<Input type="email" name="email" />} />
          <Label
            text="Password:"
            input={<Input type="password" name="password" />}
          />
          <Button text="Create Manager" />
        </form>
      </div>
    </div>
  );
};

export default CreateManager;
