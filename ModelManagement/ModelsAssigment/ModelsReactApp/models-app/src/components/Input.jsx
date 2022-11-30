import React from "react";

const Input = ({ type, name }) => {
  return (
    <input
      className="ml-2 border-2 rounded border-white px-2 py-1 hover:bg-blue-300 bg-blue-600 text-white font-semibold"
      type={type}
      name={name}
    />
  );
};

export default Input;
