// Copyright (c) 2024 - Jun Dev. All rights reserved

import { createSlice } from '@reduxjs/toolkit';

export enum ThemeEnum {
  Light = 'light',
  Dark = 'dark',
}

const themeSlice = createSlice({
  name: 'theme',
  initialState: {
    mode: ThemeEnum.Light,
  },
  reducers: {
    toggleTheme: (state) => {
      state.mode =
        state.mode === ThemeEnum.Light ? ThemeEnum.Dark : ThemeEnum.Light;
    },
  },
});

export const { toggleTheme } = themeSlice.actions;
export default themeSlice.reducer;
