// Copyright (c) 2024 - Jun Dev. All rights reserved

import { changeLanguage } from 'i18next';
import { useEffect } from 'react';
import { useTranslation } from 'react-i18next';
import { useSelector } from 'react-redux';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import { CssBaseline, ThemeProvider } from './components';
import { routeConfigs } from './config';
import { languageSelector, themeSelector } from './redux/selectors';
import { ThemeEnum } from './redux/slices/themeSlice';
import { lightTheme, darkTheme } from './themes';
import './App.scss';

function App() {
  const theme = useSelector(themeSelector);
  const lang = useSelector(languageSelector);
  const { t: translate } = useTranslation();

  useEffect(() => {
    const bodyClassList = document.body.classList;
    const DARK_THEME_CLASS = 'dark-theme';
    const isContain = bodyClassList.contains('dark-theme');
    if (theme === ThemeEnum.Dark && !isContain) {
      bodyClassList.add(DARK_THEME_CLASS);
    }
    if (theme === ThemeEnum.Light && isContain) {
      bodyClassList.remove(DARK_THEME_CLASS);
    }
  }, [theme]);

  useEffect(() => {
    changeLanguage(lang);
  }, [lang]);

  const replaceContent = (input: string) => {
    input = input.replaceAll(
      '{site_name}',
      process.env.REACT_APP_APP_NAME || '',
    );
    return input;
  };

  //const { data, isLoading } = useApiService<getProductByCriteriaRequest, IProduct[]>(getProductByCriteria);
  return (
    <ThemeProvider theme={theme === ThemeEnum.Light ? lightTheme : darkTheme}>
      <CssBaseline />
      <div className="App">
        <BrowserRouter>
          <Routes>
            {routeConfigs.map((routeItem, index) => {
              const { title, description, path, Layout, Page } = routeItem;

              return (
                <Route
                  key={index}
                  path={path}
                  element={
                    <Layout
                      title={replaceContent(translate(title))}
                      description={replaceContent(translate(description))}
                    >
                      <Page />
                    </Layout>
                  }
                />
              );
            })}
          </Routes>
        </BrowserRouter>
      </div>
    </ThemeProvider>
  );
}

export default App;
