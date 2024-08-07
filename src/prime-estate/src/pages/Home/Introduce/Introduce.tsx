// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Container, Grid, Typography } from '../../../components';
import './Introduce.scss';

const Introduce: React.FC = () => {
  return (
    <section className="homeIntroduce">
      <Container maxWidth="lg">
        <Grid container spacing={8}>
          <Grid item md={5} sm={12}>
            <div className="homeIntroduce__picture">
              <img src="/images/background/home-introduce.jpg" />
            </div>
          </Grid>
          <Grid item md={7} sm={12}>
            <Typography variant="h1">Prime Land</Typography>
            <Typography variant="body1">What is Lorem Ipsum?</Typography>
            <Typography variant="body2" align="left">
              Lorem Ipsum is simply dummy text of the printing and typesetting
              industry. Lorem Ipsum has been the industry's standard dummy text
              ever since the 1500s, when an unknown printer took a galley of
              type and scrambled it to make a type specimen book. It has
              survived not only five centuries, but also the leap into
              electronic typesetting, remaining essentially unchanged. It was
              popularised in the 1960s with the release of Letraset sheets
              containing Lorem Ipsum passages, and more recently with desktop
              publishing software like Aldus PageMaker including versions of
              Lorem Ipsum.
            </Typography>
          </Grid>
        </Grid>
      </Container>
    </section>
  );
};

export default Introduce;
