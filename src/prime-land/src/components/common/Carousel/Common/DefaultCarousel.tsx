// Copyright (c) 2024 - Jun Dev. All rights reserved

/* eslint-disable */
import { Swiper, SwiperProps } from 'swiper/react';

export interface CarouselProps extends SwiperProps {}

const CarouselComponent = (props: CarouselProps) => {
  const { children, ...carouselProps } = props;
  return <Swiper {...carouselProps}>{children}</Swiper>;
};

export default CarouselComponent;
