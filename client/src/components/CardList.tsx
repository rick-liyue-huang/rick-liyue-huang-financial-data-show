import React from 'react';
import { Card } from './Card';

interface Props {}

export const CardList = (props: Props) => {
  return (
    <div>
      <Card companyName='Apple' ticker='AAPL' price={100} />
      <Card companyName='Tesla' ticker='TSLA' price={200} />
      <Card companyName='Microsoft' ticker='MSFT' price={250} />
    </div>
  );
};
