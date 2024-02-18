import React from 'react';

interface Props {
  companyName: string;
  price: number;
  ticker: string;
}

export const Card = (props: Props) => {
  return (
    <div className='card'>
      <img
        src='https://images.unsplash.com/photo-1612428978260-2b9c7df20150?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80'
        alt='card-img'
      />
      <div className='details'>
        <h2>
          {props.companyName}({props.ticker})
        </h2>
        <p>${props.price}</p>
      </div>
      <p className='info'>this is the content of the card</p>
    </div>
  );
};
