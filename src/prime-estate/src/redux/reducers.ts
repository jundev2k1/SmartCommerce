// Copyright (c) 2024 - Jun Dev. All rights reserved

import { combineReducers } from 'redux';
import { themeReducer } from './slices';

const rootReducers = combineReducers({
  theme: themeReducer,
});

export default rootReducers;
