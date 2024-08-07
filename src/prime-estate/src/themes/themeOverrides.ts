// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Components } from '@mui/material/styles/components';

const themeOverrides: Components = {
  MuiButton: {
    styleOverrides: {
      root: {
        borderRadius: '8px',
        fontFamily: 'Roboto'
      },
    },
  },
  MuiTypography: {
    styleOverrides: {
      h1: {
        fontFamily: '"Bona Nova SC", serif',
        fontSize: '3.75rem',
      },
      h2: {
        fontFamily: '"Bona Nova SC", serif',
        fontSize: '2.5rem',
      }
    }
  }
};

export default themeOverrides;
