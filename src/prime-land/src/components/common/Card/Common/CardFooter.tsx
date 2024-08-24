// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Box, BoxProps } from '@mui/material';
import React from 'react';

import { createClassName } from '../../../../utils';

interface CardFooterProps extends BoxProps {
  children: React.ReactNode;
}

const CardFooterComponent = (props: CardFooterProps) => {
  const { children, className, ...wrapperProps } = props;
  return (
    <Box
      component="div"
      className={createClassName('card__footer', className)}
      {...wrapperProps}
    >
      {children}
    </Box>
  );
};

export default CardFooterComponent;
