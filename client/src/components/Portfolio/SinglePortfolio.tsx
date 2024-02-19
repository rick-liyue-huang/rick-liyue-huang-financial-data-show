import React from 'react';

interface Props {
  value: string;
}

export const SinglePortfolio = (props: Props) => {
  return (
    <div>
      <h4>{props.value}</h4>
      <button>Delete</button>
    </div>
  );
};
