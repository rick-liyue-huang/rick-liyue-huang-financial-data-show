import React, { SyntheticEvent } from 'react';
import { SinglePortfolio } from './SinglePortfolio';

interface Props {
  portfolioValues: string[];
  handleDeletePortfolio: (e: SyntheticEvent) => void;
}

export const ListPortfolio = (props: Props) => {
  return (
    <div>
      <h3 className='mb-3 mt-3 text-3xl font-semibold text-center md:text-4xl'>
        My Portfolio
      </h3>
      <div className='relative flex flex-col items-center max-w-5xl mx-auto space-y-10 px-10 mb-5 md:px-6 md:space-y-0 md:space-x-7 md:flex-row'>
        <>
          {props.portfolioValues.length > 0 ? (
            props.portfolioValues.map((value: string) => (
              <SinglePortfolio
                key={value}
                value={value}
                handleDeletePortfolio={props.handleDeletePortfolio}
              />
            ))
          ) : (
            <h3 className='mb-3 mt-3 text-xl font-semibold text-center md:text-xl'>
              Your portfolio is empty.
            </h3>
          )}
        </>
      </div>
    </div>
  );
};
