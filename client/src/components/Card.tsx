import React from 'react';
import { CompanySearch } from '../company';
import { AddPortfolio } from './Portfolio/AddPortfolio';
import { Link } from 'react-router-dom';

interface Props {
  id: string;
  searchResult: CompanySearch;
  handleCreatePortfolio: (e: React.SyntheticEvent) => void;
}

export const Card = ({ id, searchResult, handleCreatePortfolio }: Props) => {
  return (
    <div className='card'>
      <img
        src='https://images.unsplash.com/photo-1612428978260-2b9c7df20150?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80'
        alt='card-img'
      />
      <div className='details'>
        <Link
          to={`/company/${searchResult.symbol}`}
          className='font-bold text-center md:text-ellipsis'
        >
          {searchResult.name}({searchResult.symbol})
        </Link>
        <p>{searchResult.currency}</p>
      </div>
      <p className='info'>
        {searchResult.exchangeShortName} - {searchResult.stockExchange}
      </p>
      <AddPortfolio
        symbol={searchResult.symbol}
        handleCreatePortfolio={handleCreatePortfolio}
      />
    </div>
  );
};
