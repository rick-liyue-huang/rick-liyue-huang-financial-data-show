import React from 'react';

interface Props {
  value: string;
  handleDeletePortfolio: (e: React.SyntheticEvent) => void;
}

export const DeletePortfolio = (props: Props) => {
  return (
    <div>
      <form onSubmit={props.handleDeletePortfolio}>
        <input type='text' readOnly={true} hidden={true} value={props.value} />
        <button
          className='block w-full py-3 text-white duration-200 border-2 rounded-lg bg-red-500 hover:text-red-500 hover:bg-white border-red-500'
          type='submit'
        >
          Delete
        </button>
      </form>
    </div>
  );
};
