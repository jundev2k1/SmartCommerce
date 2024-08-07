// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Container, Typography } from '../../components';
import { HomeCarousel } from './Carousel';
import { HomeIntroduce } from './Introduce';
import './HomePage.scss';

const HomePage: React.FC = () => {
  return (
    <>
      <HomeCarousel />
      <HomeIntroduce />
      <HomeIntroduce />
      <HomeIntroduce />
      <HomeIntroduce />
    </>
  );
};

export default HomePage;
