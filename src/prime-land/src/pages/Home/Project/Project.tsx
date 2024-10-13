// Copyright (c) 2024 - Jun Dev. All rights reserved

import { useProject } from './project.logic';
import {
  Box,
  Grid,
  Skeleton,
  Typography,
  Carousel,
  CarouselItem,
  CardCategory,
} from '../../../components';

const HomeProject: React.FC = () => {
  const { isLoading, data } = useProject();
  return (
    <Box
      component="section"
      className="homeProject"
      sx={{ margin: '3.5rem 0', padding: '0 .875rem' }}
    >
      <Typography
        variant="h2"
        sx={{ textAlign: 'center', marginBottom: '2rem' }}
      >
        DANH SÁCH DỰ ÁN
      </Typography>
      {isLoading ? (
        <Grid container>
          {Array<number>(3).map((num: number) => (
            <Grid key={num} item md={4} sm={6}>
              <Skeleton />
            </Grid>
          ))}
        </Grid>
      ) : (
        <Carousel
          spaceBetween={30}
          slidesPerView={3}
          breakpoints={{
            640: { slidesPerView: 1 },
            768: { slidesPerView: 2 },
            1024: { slidesPerView: 3 },
          }}
        >
          {data?.map((category, index) => (
            <CarouselItem key={index} style={{ padding: '4px 0' }}>
              <CardCategory data={category}>
                <Box>
                  <Typography variant="h3">{category.categoryName}</Typography>
                  <Typography variant="body1">
                    {category.description}
                  </Typography>
                </Box>
              </CardCategory>
            </CarouselItem>
          ))}
        </Carousel>
      )}
    </Box>
  );
};

export default HomeProject;
