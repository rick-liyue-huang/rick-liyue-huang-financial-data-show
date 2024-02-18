import React, { SyntheticEvent, useState } from 'react';
import './App.css';

import { CardList } from './components/CardList';
import { Search } from './components/Search';

function App() {
  const [search, setSearch] = useState<string>('');

  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    e.preventDefault();
    setSearch(e.target.value);
    console.log(search);
  };

  const handleClick = (e: SyntheticEvent) => {
    e.preventDefault();
    console.log(search);
  };

  return (
    <div className='App'>
      <Search
        handleSearch={handleSearch}
        search={search}
        handleClick={handleClick}
      />
      <CardList />
    </div>
  );
}

export default App;
