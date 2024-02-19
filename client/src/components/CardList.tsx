import React from 'react';
import { Card } from './Card';
import { CompanySearch } from '../company';
import { v4 as uuidv4 } from 'uuid';

interface Props {
  searchResults: CompanySearch[];
  handleCreatePortfolio: (e: React.SyntheticEvent) => void;
}

export const CardList = (props: Props) => {
  return (
    <div>
      {props.searchResults.map((company: CompanySearch) => (
        <Card
          id={company.symbol}
          key={uuidv4()}
          searchResult={company}
          handleCreatePortfolio={props.handleCreatePortfolio}
        />
      ))}
    </div>
  );
};
