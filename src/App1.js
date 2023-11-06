import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import TopNav from './TopNav';
import CarRentP from './CarRentP';
import Insertrese from './Insertrese';
import Home from './Home';

const App1 = () => {
  return (
    <Router>
      <TopNav />
      <Routes>
        <Route path="/Home" element={<Home />} />
        <Route path="/CarRentP" element={<CarRentP />} />
        <Route path="/Insertrese" element={<Insertrese />} />
      </Routes>
    </Router>
  );
};

export default App1;