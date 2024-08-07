// Copyright (c) 2024 - Jun Dev. All rights reserved

import { ThemeOptions } from '@mui/material/styles';
import themeOverrides from './themeOverrides';

const darkThemeOptions: ThemeOptions = {
  palette: {
    mode: 'dark',
    primary: {
      main: '#90caf9',
    },
    secondary: {
      main: '#f48fb1',
    },
    background: {
      default: '#303030',
    },
  },
  components: themeOverrides,
};

export default darkThemeOptions;
