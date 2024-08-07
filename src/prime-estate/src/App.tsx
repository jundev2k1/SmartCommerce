// Copyright (c) 2024 - Jun Dev. All rights reserved

import { useState } from 'react';
import { CssBaseline, ThemeProvider } from './components';
import { lightTheme, darkTheme } from './themes';
import './App.scss';
import { NavBar } from './components';
import { HomePage } from './pages';

function App() {
  const [isDarkMode, setIsDarkMode] = useState(false);
  //const { data, isLoading } = useApiService<getProductByCriteriaRequest, IProduct[]>(getProductByCriteria);

  return (
    <ThemeProvider theme={isDarkMode ? darkTheme : lightTheme}>
      <CssBaseline />
      <div className="App">
        <NavBar />
        <HomePage />
      </div>
    </ThemeProvider>
  );
}

export default App;
