import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./pages/Layout";
import Home from "./pages/Home";
import Job from "./pages/Job";
import Model from "./pages/Model";
import Manager from "./pages/Manager";
import NoPage from "./pages/NoPage";
import "./index.css";
export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="Model" element={<Model />} />
          <Route path="Manager" element={<Manager />} />
          <Route path="Job" element={<Job />} />
          <Route path="*" element={<NoPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App />);
