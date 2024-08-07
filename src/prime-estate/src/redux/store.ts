// Copyright (c) 2024 - Jun Dev. All rights reserved

import { configureStore } from '@reduxjs/toolkit';
import { themeReducer } from './slices';
import rootReducers from './reducers';

export const store = configureStore({
  reducer: rootReducers,
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
