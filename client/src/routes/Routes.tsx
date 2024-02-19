import { createBrowserRouter } from 'react-router-dom';
import HomePage from '../pages/HomePage';
import CompanyPage from '../pages/CompanyPage';
import SearchPage from '../pages/SearchPage';
import App from '../App';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      {
        path: '/',
        element: <HomePage />,
      },
      {
        path: '/company',
        element: <CompanyPage />,
      },
      {
        path: '/search',
        element: <SearchPage />,
      },
    ],
  },
]);
