// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Box, BoxProps } from '@mui/material';
import React from 'react';

import { createClassName } from '../../../../utils';

interface CardHeadProps extends BoxProps {
  children: React.ReactNode;
}

const CardHeadComponent = (props: CardHeadProps) => {
  const { children, className, ...wrapperProps } = props;
  return (
    <Box
      component="div"
      className={createClassName('card__head', className)}
      {...wrapperProps}
    >
      {children}
    </Box>
  );
};

export default CardHeadComponent;
