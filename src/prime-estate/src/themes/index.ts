// Copyright (c) 2024 - Jun Dev. All rights reserved

import { createTheme, Theme } from '@mui/material/styles';
import lightThemeOptions from './lightTheme';
import darkThemeOptions from './darkTheme';

export const lightTheme: Theme = createTheme(lightThemeOptions);
export const darkTheme: Theme = createTheme(darkThemeOptions);
