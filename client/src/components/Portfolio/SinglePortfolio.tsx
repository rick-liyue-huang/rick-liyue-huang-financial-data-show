import React from 'react';
import { DeletePortfolio } from './DeletePortfolio';
import { Link } from 'react-router-dom';

interface Props {
  value: string;
  handleDeletePortfolio: (e: React.SyntheticEvent) => void;
}

export const SinglePortfolio = (props: Props) => {
  return (
    <div className='flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3'>
      <Link to={`/company/${props.value}`} className='"pt-6 text-xl font-bold'>
        {props.value}
      </Link>
      <DeletePortfolio
        handleDeletePortfolio={props.handleDeletePortfolio}
        value={props.value}
      />
    </div>
  );
};
