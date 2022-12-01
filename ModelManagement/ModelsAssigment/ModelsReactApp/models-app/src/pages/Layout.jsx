import { Outlet, Link } from "react-router-dom";

const Layout = () => {
  return (
    <>
      <nav>
        <ul className="flex border-b">
          <li className="mt-2 mx-2 pt-2 mr-1">
            <Link
              className="bg-white inline-block rounded-t py-2 px-4 text-blue-700 font-semibold hover:bg-blue-200 hover:text-white"
              to="/"
            >
              Home
            </Link>
          </li>
          <li className="mt-2 mx-2 pt-2 mr-1">
            <Link
              className="bg-white inline-block rounded-t py-2 px-4 text-blue-700 font-semibold hover:bg-blue-200 hover:text-white"
              to="/Model"
            >
              Model
            </Link>
          </li>
          <li className="mt-2 mx-2 pt-2 mr-1">
            <Link
              className="bg-white inline-block rounded-t py-2 px-4 text-blue-700 font-semibold hover:bg-blue-200 hover:text-white"
              to="/Manager"
            >
              Manager
            </Link>
          </li>
          <li className="mt-2 mx-2 pt-2 mr-1">
            <Link
              className="bg-white inline-block rounded-t py-2 px-4 text-blue-700 font-semibold hover:bg-blue-200 hover:text-white"
              to="/Job"
            >
              Job
            </Link>
          </li>
        </ul>
      </nav>
      <div className="bg-blue-200 p-4 min-h-screen">
        <Outlet />
      </div>
    </>
  );
};

export default Layout;
