import React from "react";
import AddModelToJob from "../components/AddModelToJob";
import RemoveModelFromJob from "../components/RemoveModelFromJob";
import CreateManager from "../components/CreateManager";
import CreateModel from "../components/CreateModel";
import CreateJob from "../components/CreateJob";

const Manager = () => {
  return (
    <>
      <div className="flex flex-wrap">
        <div>
          <CreateManager />
          <CreateJob />
        </div>
        <CreateModel />
      </div>
      <div className="flex flex-wrap">
        <AddModelToJob />
        <RemoveModelFromJob />
      </div>
    </>
  );
};

export default Manager;
