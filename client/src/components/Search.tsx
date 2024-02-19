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
    <div className='relative bg-gray-100'>
      <div className='max-w-4xl mx-auto p-6 space-y-6'>
        <form
          className='form relative flex flex-col w-full p-10 space-y-4 bg-darkBlue rounded-lg md:flex-row md:space-y-0 md:space-x-3'
          onSubmit={handleSearchSubmit}
        >
          <input
            type='text'
            value={search}
            onChange={handleSearch}
            className='flex-1 p-3 border-2 rounded-lg placeholder-black focus:outline-none'
            id='search-input'
          />
          <button type='submit'>Search</button>
        </form>
      </div>
    </div>
  );
};
