// Copyright (c) 2024 - Jun Dev. All rights reserved
import { lazy, Suspense } from 'react';

import { HomeCarousel } from './Carousel';
import { Box, Container, Footer, Skeleton } from '../../components';
import './HomePage.scss';

const HomeSearch = lazy(() =>
  import('./Search').then((module) => ({ default: module.HomeSearch })),
);
const HomeIntroduce = lazy(() =>
  import('./Introduce').then((module) => ({ default: module.HomeIntroduce })),
);
const HomeProject = lazy(() =>
  import('./Project').then((module) => ({ default: module.HomeProject })),
);
const HomeWhyChooseUs = lazy(() =>
  import('./WhyChooseUs').then((module) => ({
    default: module.HomeWhyChooseUs,
  })),
);

const LayoutLoading = () => {
  return (
    <Box width="100%" margin="4px 0">
      <Container maxWidth="lg">
        <Skeleton height={200} />
      </Container>
    </Box>
  );
};

const HomePage: React.FC = () => {
  return (
    <>
      <HomeCarousel />

      <Suspense fallback={<LayoutLoading />}>
        <HomeSearch />
      </Suspense>

      <Suspense fallback={<LayoutLoading />}>
        <HomeIntroduce />
      </Suspense>

      <Suspense fallback={<LayoutLoading />}>
        <HomeProject />
      </Suspense>

      <Suspense fallback={<LayoutLoading />}>
        <HomeWhyChooseUs />
      </Suspense>

      <Suspense fallback={<LayoutLoading />}>
        <Footer />
      </Suspense>
    </>
  );
};

export default HomePage;
