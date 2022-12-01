import React from "react";

const Input = ({ type, name }) => {
  return (
    <input
      className="mx-2 my-1 border-2 rounded border-white px-2 py-1 hover:bg-blue-300 bg-blue-600 text-white font-semibold"
      type={type}
      name={name}
    />
  );
};

export default Input;
