import React, { SyntheticEvent } from 'react';

interface Props {
  handleCreatePortfolio: (e: SyntheticEvent) => void;
  symbol: string;
}

export const AddPortfolio = (props: Props) => {
  return (
    <div>
      <form onSubmit={props.handleCreatePortfolio}>
        <input
          type='text'
          readOnly={true}
          hidden={true}
          placeholder='Portfolio Name'
          value={props.symbol}
        />
        <button type='submit'>Create Portfolio</button>
      </form>
    </div>
  );
};
