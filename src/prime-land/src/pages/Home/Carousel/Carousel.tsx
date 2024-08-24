// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Container, Typography, Box } from '../../../components';
import './Carousel.scss';

const HomeCarousel: React.FC = () => {
  return (
    <Box component="section" className="homeCarousel">
      <video autoPlay muted loop id="homeBackground">
        <source src="/images/background/home-background.mp4" type="video/mp4" />
      </video>
      <Container maxWidth="lg">
        <Box className="homeCarousel__textBox">
          <Typography variant="h2">Dự án</Typography>
          <Typography variant="body1">
            qeqweqwfjghjghjghjgjgjhagsdhgas hdgas hdgash gdahsgd sahgd hasgdghas
            dhag jhdgas hdgas hdga shgd
          </Typography>
          <Typography variant="body2">qeqweqw</Typography>
        </Box>
      </Container>
    </Box>
  );
};

export default HomeCarousel;
