// Copyright (c) 2024 - Jun Dev. All rights reserved

import { ThemeOptions } from '@mui/material/styles';
import themeOverrides from './themeOverrides';

const lightThemeOptions: ThemeOptions = {
  palette: {
    mode: 'light',
    primary: {
      main: '#1976d2',
    },
    secondary: {
      main: '#dc004e',
    },
    background: {
      default: '#f4f6f8',
    },
  },
  components: themeOverrides,
};

export default lightThemeOptions;
