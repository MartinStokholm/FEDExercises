import React from "react";

const Button = ({ text }) => {
  return (
    <button className="border-2 rounded border-white bg-blue-600 m-4 px-4 py-1 text-white hover:bg-blue-300 font-semibold">
      {text}
    </button>
  );
};

export default Button;
