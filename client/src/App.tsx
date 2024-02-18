import React from 'react';
import './App.css';

import { CardList } from './components/CardList';
import { Search } from './components/Search';

function App() {
  return (
    <div className='App'>
      <Search />
      <CardList />
    </div>
  );
}

export default App;
