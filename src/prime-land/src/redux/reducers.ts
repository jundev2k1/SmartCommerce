// Copyright (c) 2024 - Jun Dev. All rights reserved
import { combineReducers } from 'redux';

import { languageReducer, themeReducer } from './slices';

const rootReducers = combineReducers({
  theme: themeReducer,
  language: languageReducer,
});

export default rootReducers;
