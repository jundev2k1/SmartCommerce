// Copyright (c) 2024 - Jun Dev. All rights reserved
import { Components } from '@mui/material';

const themeOverrides: Components = {
  MuiButton: {
    styleOverrides: {
      root: {
        borderRadius: '8px',
        fontFamily: 'Roboto',
      },
    },
  },
  MuiTypography: {
    styleOverrides: {
      h1: {
        fontFamily: '"Bona Nova SC", serif',
        fontSize: '3rem',
      },
      h2: {
        fontFamily: '"Bona Nova SC", serif',
        fontSize: '2rem',
      },
      h3: {
        fontSize: '1.5rem',
      },
      h4: {
        fontSize: '1.125rem',
      },
      h5: {
        fontSize: '1rem',
      },
      h6: {
        fontSize: '.875rem',
      },
    },
  },
  MuiCard: {
    styleOverrides: {
      root: {
        borderRadius: '8px',
      },
    },
  },
};

export default themeOverrides;
