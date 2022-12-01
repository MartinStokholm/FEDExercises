import React from "react";
import Button from "./utils/Button";
import Label from "./utils/Label";
import Input from "./utils/Input";
import Heading from "./utils/Heading";

const AddModelToJob = () => {
  return (
    <div className="mx-2">
      <Heading text="Add Model to a Job" />
      <div className="flex justify-start">
        <form className="flex flex-col items-end bg-white">
          <Label text="Job Id:" input={<Input type="number" name="jobId" />} />
          <Label
            text="Model Id:"
            input={<Input type="number" name="modelId" />}
          />
          <Button text="Submit" />
        </form>
      </div>
    </div>
  );
};

export default AddModelToJob;
