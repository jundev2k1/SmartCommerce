// Copyright (c) 2024 - Jun Dev. All rights reserved

export interface NavbarItem {
  name: string;
  url: string;
  items?: NavbarItem[];
}

export const navBarList: readonly NavbarItem[] = Object.freeze([
  {
    name: 'navbar_home',
    url: '/',
    items: [],
  },
  {
    name: 'navbar_project',
    url: '/project',
    items: [
      {
        name: 'navbar_project_projectLand',
        url: '/project',
      },
      {
        name: 'navbar_project_socialHouse',
        url: '/project',
      },
      {
        name: 'navbar_project_apartment',
        url: '/project',
      },
    ],
  },
  {
    name: 'navbar_product',
    url: '/product',
    items: [
      {
        name: 'navbar_product_goodPrice',
        url: '/product',
      },
      {
        name: 'navbar_product_urgentSale',
        url: '/product',
      },
    ],
  },
  {
    name: 'navbar_aboutUs',
    url: '/about-us',
    items: [],
  },
  {
    name: 'navbar_contactUs',
    url: '/contact-us',
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
