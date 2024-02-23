import axios from 'axios';
import { CompanyProfile, CompanySearch } from './company';

interface Response {
  data: CompanySearch[];
}

export const searchCompanies = async (query: string) => {
  try {
    const data = await axios.get<Response>(
      `https://financialmodelingprep.com/api/v3/search?query=${query}&limit=10&exchange=NASDAQ&apikey=${process.env.REACT_APP_API_KEY}`
    );
    return data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.log('Axios Error:', error.message);
      return error.message;
    } else {
      console.log('Unexpected Error:', error);
      return 'An unexpected error occurred';
    }
  }
};

export const getCompanyDetails = async (symbol: string) => {
  try {
    const data = await axios.get<CompanyProfile[]>(
      `https://financialmodelingprep.com/api/v3/profile/${symbol}?apikey=${process.env.REACT_APP_API_KEY}`
    );
    return data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.log('Axios Error:', error.message);
      return error.message;
    } else {
      console.log('Unexpected Error:', error);
      return 'An unexpected error occurred';
    }
  }
};
