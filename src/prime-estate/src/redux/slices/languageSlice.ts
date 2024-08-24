// Copyright (c) 2024 - Jun Dev. All rights reserved

import { createSlice, PayloadAction } from '@reduxjs/toolkit';

export enum LanguageCode {
  Vietnam = 'vi',
  English = 'en',
}

const languageSlice = createSlice({
  name: 'language',
  initialState: {
    lang: LanguageCode.Vietnam,
  },
  reducers: {
    setLanguage: (state, action: PayloadAction<LanguageCode>) => {
      state.lang = action.payload;
    },
  },
});

export const { setLanguage } = languageSlice.actions;
export default languageSlice.reducer;
