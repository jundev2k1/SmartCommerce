// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Helmet } from 'react-helmet';

const DefaultMeta = () => (
  <Helmet>
    <meta name="author" content="Your Name or Company" />
    <meta name="keywords" content="React, SEO, Web Development" />
    <meta property="og:site_name" content="My Awesome Site" />
    <meta property="og:type" content="website" />
    <meta property="og:image" content="https://example.com/default-image.jpg" />
    <meta name="twitter:card" content="summary_large_image" />
  </Helmet>
);

export default DefaultMeta;
