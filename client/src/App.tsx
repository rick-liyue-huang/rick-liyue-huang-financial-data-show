import React, { SyntheticEvent, useState } from 'react';
import './App.css';

import { CardList } from './components/CardList';
import { Search } from './components/Search';
import { CompanySearch } from './company';
import { searchCompanies } from './api';
import { ListPortfolio } from './components/Portfolio/ListPortfolio';

function App() {
  const [search, setSearch] = useState<string>('');
  const [searchResults, setSearchResults] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string>('');
  const [portfolioValues, setPortfolioValues] = useState<string[]>([]);

  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    e.preventDefault();
    setSearch(e.target.value);
    console.log(search);
  };

  const handleSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const results = await searchCompanies(search);
    if (typeof results === 'string') {
      setServerError(results);
    } else if (Array.isArray(results.data)) {
      setSearchResults(results.data);
    }

    console.log(searchResults);
  };

  const handleCreatePortfolio = (e: any) => {
    e.preventDefault();

    const existingPortfolio = portfolioValues.find(
      (value) => value === e.target[0].value
    );

    if (existingPortfolio) {
      return;
    }

    const updatedPortfolio = [...portfolioValues, e.target[0].value];
    setPortfolioValues(updatedPortfolio);
    console.log('Portfolio created');
  };

  return (
    <div className='App'>
      <Search
        handleSearch={handleSearch}
        search={search}
        handleSearchSubmit={handleSearchSubmit}
      />
      <ListPortfolio portfolioValues={portfolioValues} />
      {serverError && <p>{serverError}</p>}
      <CardList
        searchResults={searchResults}
        handleCreatePortfolio={handleCreatePortfolio}
      />
    </div>
  );
}

export default App;
