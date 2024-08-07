// Copyright (c) 2024 - Jun Dev. All rights reserved

import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';
import HttpApi from 'i18next-http-backend';
import LanguageDetector from 'i18next-browser-languagedetector';

const initConfig = {
  fallbackLng: 'vi',
  debug: true,
  interpolation: {
    escapeValue: false,
  },
  backend: {
    loadPath: '/locales/{{lng}}/{{ns}}.json',
  },
};

i18n.use(HttpApi).use(LanguageDetector).use(initReactI18next).init(initConfig);

export default i18n;
