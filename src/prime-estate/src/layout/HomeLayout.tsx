// Copyright (c) 2024 - Jun Dev. All rights reserved
import { Helmet } from 'react-helmet';

import { LayoutProps } from './common';
import { NavBar } from '../components';

const PageLayout = (props: LayoutProps): JSX.Element => {
  const { title, description, children } = props;
  return (
    <>
      <Helmet>
        <title>{title || 'Default Title'}</title>
        <meta
          name="description"
          content={description || 'Default description'}
        />
      </Helmet>
      <NavBar />
      {children}
    </>
  );
};

export default PageLayout;
