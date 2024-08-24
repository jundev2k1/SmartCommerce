// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Box, BoxProps } from '@mui/material';
import React from 'react';

import { createClassName } from '../../../../utils';

interface CardBodyProps extends BoxProps {
  children: React.ReactNode;
}

const CardBodyComponent = (props: CardBodyProps) => {
  const { children, className, ...wrapperProps } = props;
  return (
    <Box
      component="div"
      className={createClassName('card__body', className)}
      {...wrapperProps}
    >
      {children}
    </Box>
  );
};

export default CardBodyComponent;
