import React, { SyntheticEvent, useState } from 'react';
import { CompanySearch } from '../company';
import { searchCompanies } from '../api';
import { Search } from '../components/Search';
import { ListPortfolio } from '../components/Portfolio/ListPortfolio';
import { CardList } from '../components/CardList';

interface Props {}

const SearchPage = (props: Props) => {
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

  const handleDeletePortfolio = (e: any) => {
    e.preventDefault();
    const updatedPortfolio = portfolioValues.filter(
      (value) => value !== e.target[0].value
    );
    setPortfolioValues(updatedPortfolio);
  };

  return (
    <div>
      {/* <Hero /> */}
      <Search
        handleSearch={handleSearch}
        search={search}
        handleSearchSubmit={handleSearchSubmit}
      />
      <ListPortfolio
        portfolioValues={portfolioValues}
        handleDeletePortfolio={handleDeletePortfolio}
      />
      {serverError && <p>{serverError}</p>}
      <CardList
        searchResults={searchResults}
        handleCreatePortfolio={handleCreatePortfolio}
      />
    </div>
  );
};

export default SearchPage;
