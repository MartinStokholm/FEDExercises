import React from "react";
import Button from "./utils/Button";
import Label from "./utils/Label";
import Input from "./utils/Input";
import Heading from "./utils/Heading";

const CreateModel = () => {
  return (
    <div className="mx-2">
      <Heading text="Create Model" />
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
            text="Phone number:"
            input={<Input type="number" name="phoneNumber" />}
          />
          <Label
            text="Addres line 1:"
            input={<Input type="text" name="addresLine1" />}
          />
          <Label
            text="Addres line 2:"
            input={<Input type="text" name="addresLine2" />}
          />
          <Label text="Zip:" input={<Input type="number" name="zip" />} />
          <Label text="City:" input={<Input type="text" name="city" />} />
          <Label text="Country:" input={<Input type="text" name="country" />} />
          <Label
            text="Birthday:"
            input={<Input type="text" name="birthday" />}
          />
          <Label
            text="Nationality:"
            input={<Input type="text" name="nationality" />}
          />
          <Label text="Height:" input={<Input type="number" name="height" />} />
          <Label
            text="Shoe size:"
            input={<Input type="number" name="shoeSize" />}
          />
          <Label
            text="Hair color:"
            input={<Input type="text" name="hairColor" />}
          />
          <Label
            text="Eye color:"
            input={<Input type="text" name="eyeColor" />}
          />
          <Label
            text="Comments:"
            input={<Input type="text" name="comments" />}
          />
          <Label
            text="Password:"
            input={<Input type="password" name="password" />}
          />
          <Button text="Create Model" />
        </form>
      </div>
    </div>
  );
};

export default CreateModel;
