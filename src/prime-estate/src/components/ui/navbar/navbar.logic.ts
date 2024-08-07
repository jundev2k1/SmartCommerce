// Copyright (c) 2024 - Jun Dev. All rights reserved

interface NavbarItem {
  Icon: string;
  name: string;
  url: string;
  items?: NavbarItem[];
}

export const navBarList: readonly NavbarItem[] = Object.freeze([
  {
    Icon: '',
    name: 'navbar_home',
    url: '',
    items: [],
  },
  {
    Icon: '',
    name: 'navbar_project',
    url: '',
    items: [],
  },
]);

enum LanguageCode {
  VIETNAMESE = 'vi',
  ENGLISH = 'en',
}

interface LanguageItem {
  image: string;
  name: string;
  languageCode: LanguageCode;
}

export const languageList: readonly LanguageItem[] = Object.freeze([
  {
    image: '/images/flags/vi.png',
    name: 'Vietnamese',
    languageCode: LanguageCode.VIETNAMESE,
  },
  {
    image: '/images/flags/uk.png',
    name: 'USA',
    languageCode: LanguageCode.ENGLISH,
  },
]);
