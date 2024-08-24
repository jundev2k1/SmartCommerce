// Copyright (c) 2024 - Jun Dev. All rights reserved

import { createTheme, Theme } from '@mui/material/styles';

import darkThemeOptions from './darkTheme';
import lightThemeOptions from './lightTheme';

export const lightTheme: Theme = createTheme(lightThemeOptions);
export const darkTheme: Theme = createTheme(darkThemeOptions);
