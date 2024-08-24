// Copyright (c) 2024 - Jun Dev. All rights reserved

import FooterAbsoluteComponent from './FooterAbsolute';
import FooterInformationComponent from './FooterInformation';
import './Footer.scss';

const FooterComponent = () => {
  return (
    <footer>
      <FooterInformationComponent />
      <FooterAbsoluteComponent />
    </footer>
  );
};

export default FooterComponent;
