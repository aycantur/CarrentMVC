import React from 'react';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import CarrentPage from './CarRentP';
import Insertrese from './Insertrese';
import Home from './Home';


const MenuNav = () => {
  return (
    <BrowserRouter>
      <div>
        <nav>
          <Link to="/CarRentP">Rezervasyon Listesi</Link>
          <Link to="/Home">AnaSayfa</Link>
          <Link to="/Insertrese">Rezervasyon Oluştur</Link>
        </nav>

        <Routes>
          <Route path="/CarRentP" element={<CarrentPage />} />
          <Route path="/Home" element={<Home />} />
          <Route path="/Insertrese" element={<Insertrese />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
};

export default MenuNav;




