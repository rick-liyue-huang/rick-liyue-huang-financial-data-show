import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { CompanyProfile } from '../company';
import { getCompanyDetails } from '../api';

interface Props {}

const CompanyPage = (props: Props) => {
  const [company, setCompany] = useState<CompanyProfile>();

  const { ticker } = useParams();

  useEffect(() => {
    const getCompanyDetail = async () => {
      const companyDetails = await getCompanyDetails(ticker!);
      if (typeof companyDetails === 'string') {
        console.log(companyDetails);
        return;
      }
      setCompany(companyDetails?.data[0]);
    };
    getCompanyDetail();
  }, []);

  return (
    <div>
      {company && (
        <div>
          <h1>{company.companyName}</h1>
          <h2>{company.exchange}</h2>
          <h3>{company.industry}</h3>
          <h3>{company.sector}</h3>
          <h3>{company.description}</h3>
          <h3>{company.website}</h3>
        </div>
      )}
    </div>
  );
};

export default CompanyPage;
