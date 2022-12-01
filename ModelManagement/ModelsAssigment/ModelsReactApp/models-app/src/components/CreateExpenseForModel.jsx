import React from "react";
import Button from "./utils/Button";
import Label from "./utils/Label";
import Input from "./utils/Input";
import Heading from "./utils/Heading";

const CreateExpenseForModel = () => {
  return (
    <div>
      <Heading text="Create expense for a Model" />
      <div className="flex justify-start">
        <form className="flex flex-col items-end bg-white">
          <Label
            text="Model Id:"
            input={<Input type="number" name="modelId" />}
          />
          <Label text="Job Id:" input={<Input type="number" name="jobId" />} />

          <Label text="Date:" input={<Input type="text" name="date" />} />
          <Label text="Text:" input={<Input type="text" name="text" />} />
          <Label text="Amount:" input={<Input type="number" name="amount" />} />
          <Button text="Add expense" />
        </form>
      </div>
    </div>
  );
};

export default CreateExpenseForModel;
