import React from "react";

const Label = ({ text, input }) => {
  return (
    <label className="mx-2 my-1 font-medium">
      {text} {input}
    </label>
  );
};

export default Label;
