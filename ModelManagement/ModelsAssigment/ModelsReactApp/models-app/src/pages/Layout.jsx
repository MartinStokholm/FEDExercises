import { Outlet, Link } from "react-router-dom";

const Layout = () => {
  return (
    <>
      <nav>
        <ul className="flex border-b">
          <li className="mt-2 mx-2 pt-2 mr-1">
            <Link
              className="bg-white inline-block border-l border-t border-r rounded-t py-2 px-4 text-blue-700 font-semibold"
              to="/"
            >
              Home
            </Link>
          </li>
          <li className="mt-2 mx-2 pt-2 mr-1">
            <Link
              className="bg-white inline-block border-l border-t border-r rounded-t py-2 px-4 text-blue-700 font-semibold"
              to="/Model"
            >
              Model
            </Link>
          </li>
          <li className="mt-2 mx-2 pt-2 mr-1">
            <Link
              className="bg-white inline-block border-l border-t border-r rounded-t py-2 px-4 text-blue-700 font-semibold"
              to="/Manager"
            >
              Manager
            </Link>
          </li>
          <li className="mt-2 mx-2 pt-2 mr-1">
            <Link
              className="bg-white inline-block border-l border-t border-r rounded-t py-2 px-4 text-blue-700 font-semibold"
              to="/Job"
            >
              Job
            </Link>
          </li>
        </ul>
      </nav>

      <Outlet />
    </>
  );
};

export default Layout;
