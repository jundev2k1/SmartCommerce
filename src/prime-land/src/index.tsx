// Copyright (c) 2024 - Jun Dev. All rights reserved

import React from 'react';
import ReactDOM from 'react-dom/client';
import { Provider } from 'react-redux';

import './i18n/i18n';
import './index.scss';
import App from './App';
import { DefaultMeta } from './components';
import { store } from './redux';
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement,
);
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <DefaultMeta />
      <App />
    </Provider>
  </React.StrictMode>,
);

reportWebVitals();
