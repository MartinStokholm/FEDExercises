import React from "react";

const Label = ({ text, input }) => {
  return (
    <label className="mx-4 font-medium">
      {text} {input}
    </label>
  );
};

export default Label;
