// Copyright (c) 2024 - Jun Dev. All rights reserved

import { RootState } from './store';

// Theme selector
export const themeSelector = (state: RootState) => state.theme.mode;

// Language selector
export const languageSelector = (state: RootState) => state.language.lang;
