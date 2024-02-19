import React, { SyntheticEvent, useState } from 'react';
import './App.css';

import { CardList } from './components/CardList';
import { Search } from './components/Search';
import { CompanySearch } from './company';
import { searchCompanies } from './api';
import { ListPortfolio } from './components/Portfolio/ListPortfolio';
import { Navbar } from './components/Navbar';
import { Hero } from './components/Hero';
import { Outlet } from 'react-router';

function App() {
  return (
    <div>
      <Navbar />
      <Outlet />
    </div>
  );
}

export default App;
