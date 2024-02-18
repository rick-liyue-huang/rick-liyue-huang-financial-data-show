import React, { ChangeEvent, SyntheticEvent } from 'react';

interface Props {
  handleSearch: (e: ChangeEvent<HTMLInputElement>) => void;
  search: string | undefined;
  handleClick: (e: SyntheticEvent) => void;
}

export const Search: React.FC<Props> = ({
  handleClick,
  search,
  handleSearch,
}: Props): JSX.Element => {
  return (
    <div>
      <input type='text' value={search} onChange={handleSearch} />
      <button onClick={handleClick}>Search</button>
    </div>
  );
};
