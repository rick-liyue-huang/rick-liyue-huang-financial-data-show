import React, { ChangeEvent, SyntheticEvent } from 'react';

interface Props {
  handleSearch: (e: ChangeEvent<HTMLInputElement>) => void;
  search: string | undefined;
  handleSearchSubmit: (e: SyntheticEvent) => void;
}

export const Search: React.FC<Props> = ({
  handleSearchSubmit,
  search,
  handleSearch,
}: Props): JSX.Element => {
  return (
    <div>
      <form onSubmit={handleSearchSubmit}>
        <input type='text' value={search} onChange={handleSearch} />
        <button type='submit'>Search</button>
      </form>
    </div>
  );
};
