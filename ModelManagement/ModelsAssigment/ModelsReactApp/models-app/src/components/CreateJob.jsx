import React from "react";
import Button from "./utils/Button";
import Label from "./utils/Label";
import Input from "./utils/Input";
import Heading from "./utils/Heading";

const CreateJob = () => {
  return (
    <div className="mx-2">
      <Heading text="Create Job" />
      <div className="flex justify-start">
        <form className="flex flex-col items-end bg-white">
          <Label
            text="Customer:"
            input={<Input type="text" name="customer" />}
          />
          <Label
            text="Start date:"
            input={<Input type="text" name="startDate" />}
          />
          <Label text="Days:" input={<Input type="number" name="days" />} />
          <Label
            text="Location:"
            input={<Input type="text" name="location" />}
          />
          <Label
            text="Comments:"
            input={<Input type="text" name="comments" />}
          />
          <Button text="Create Job" />
        </form>
      </div>
    </div>
  );
};

export default CreateJob;
