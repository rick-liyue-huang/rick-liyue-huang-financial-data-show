import React from 'react';
import { SinglePortfolio } from './SinglePortfolio';

interface Props {
  portfolioValues: string[];
}

export const ListPortfolio = (props: Props) => {
  return (
    <div>
      <h3>My Portfolio</h3>
      <ul>
        {props.portfolioValues &&
          props.portfolioValues.map((value: string) => (
            <SinglePortfolio key={value} value={value} />
          ))}
      </ul>
    </div>
  );
};
