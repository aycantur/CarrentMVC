import React from 'react';
import { Link,  BrowserRouter } from 'react-router-dom';
import './TopNav.css'; // CSS dosyası

const TopNav = () => {
  return (
    <nav className="top-nav">
      <Link to="/CarRentP" className="nav-item">Rezervasyon Listesi</Link>
      <Link to="/Insertrese" className="nav-item">Rezervasyon Oluştur</Link>
    </nav>
  );
};

export default TopNav;