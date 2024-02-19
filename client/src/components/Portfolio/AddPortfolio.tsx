import React, { SyntheticEvent } from 'react';

interface Props {
  handleCreatePortfolio: (e: SyntheticEvent) => void;
  symbol: string;
}

export const AddPortfolio = (props: Props) => {
  return (
    <div className='flex flex-col items-center justify-end flex-1 space-x-4 space-y-2 md:flex-row md:space-y-0'>
      <form onSubmit={props.handleCreatePortfolio}>
        <input
          type='text'
          readOnly={true}
          hidden={true}
          placeholder='Portfolio Name'
          value={props.symbol}
        />
        <button
          type='submit'
          className='p-2 px-8 text-white bg-darkBlue rounded-lg hover:opacity-70 focus:outline-none'
        >
          Create Portfolio
        </button>
      </form>
    </div>
  );
};
