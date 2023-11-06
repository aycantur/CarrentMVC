import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import MenuNav from './MenuNav';
import CarrentPage from './CarRentP';

const MenuNav1 = () => {
  return (
    
      <div>
        <MenuNav />
        <Routes>
          <Route path="/CarRentP" element={<CarrentPage />} />
        </Routes>
      </div>
    
  );
};

export default MenuNav1;