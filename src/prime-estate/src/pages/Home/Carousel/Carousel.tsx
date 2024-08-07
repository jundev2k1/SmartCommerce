// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Container, Typography } from '../../../components';
import './Carousel.scss';

const HomeCarousel: React.FC = () => {
  return (
    <section className="homeCarousel">
      <Container maxWidth="lg">
        <div className="homeCarousel__textBox">
          <Typography variant="h2">Dự án</Typography>
          <Typography variant="body1">qeqweqwfjghjghjghjgjgjhagsdhgas hdgas hdgash gdahsgd sahgd hasgdghas dhag jhdgas hdgas hdga shgd</Typography>
          <Typography variant="body2">qeqweqw</Typography>
        </div>
      </Container>
    </section>
  );
};

export default HomeCarousel;
