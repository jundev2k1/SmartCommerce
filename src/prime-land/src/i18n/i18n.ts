// Copyright (c) 2024 - Jun Dev. All rights reserved

import i18n, { use } from 'i18next';
import LanguageDetector from 'i18next-browser-languagedetector';
import HttpApi from 'i18next-http-backend';
import { initReactI18next } from 'react-i18next';

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

use(HttpApi).use(LanguageDetector).use(initReactI18next).init(initConfig);

export default i18n;
