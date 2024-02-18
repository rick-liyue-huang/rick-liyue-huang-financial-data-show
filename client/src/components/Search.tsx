import React, { useState } from 'react';

interface Props {}

export const Search: React.FC<Props> = (props: Props): JSX.Element => {
  const [search, setSearch] = useState<string>('');

  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    e.preventDefault();
    setSearch(e.target.value);
    console.log(search);
  };

  const handleClick = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
    e.preventDefault();
    console.log(search);
  };

  return (
    <div>
      <input type='text' value={search} onChange={handleSearch} />
      <button onClick={handleClick}></button>
    </div>
  );
};
