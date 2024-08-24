// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Box, Container, Grid } from '../../../components';

const HomeSearch: React.FC = () => {
  return (
    <Box component="section" className="homeSearch">
      <Container maxWidth="lg">
        <Box className="homeSearch__wrapper">
          <Grid container>
            <Grid item md={3}></Grid>
          </Grid>
        </Box>
      </Container>
    </Box>
  );
};

export default HomeSearch;
