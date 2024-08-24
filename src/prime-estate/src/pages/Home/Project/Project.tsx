// Copyright (c) 2024 - Jun Dev. All rights reserved

import { useProject } from './project.logic';
import {
  Box,
  CardProduct,
  Container,
  Grid,
  Skeleton,
  Typography,
} from '../../../components';

const HomeProject: React.FC = () => {
  const { isLoading, data } = useProject();
  return (
    <Box
      component="section"
      className="homeProject"
      sx={{ margin: '.875rem 0' }}
    >
      <Container maxWidth="lg">
        <Box className="homeProject__wrapper">
          <Grid container spacing={2}>
            {isLoading
              ? Array<number>(3).map((num: number) => (
                  <Grid key={num} item md={4}>
                    <Skeleton />
                  </Grid>
                ))
              : data?.items.map((product, index) => (
                  <Grid key={index} item md={4}>
                    <CardProduct data={product}>
                      <Box>
                        <Typography variant="h3">{product.name}</Typography>
                        <Typography
                          variant="body1"
                          dangerouslySetInnerHTML={{
                            __html: product.description,
                          }}
                        ></Typography>
                        <Typography variant="body1">{product.price1}</Typography>
                      </Box>
                    </CardProduct>
                  </Grid>
                ))}
          </Grid>
        </Box>
      </Container>
    </Box>
  );
};

export default HomeProject;
