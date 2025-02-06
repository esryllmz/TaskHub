import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<h1>Dashboard</h1>} />
        <Route path="/login" element={<h1>Login</h1>} />
      </Routes>
    </Router>
  );
}

export default App;
