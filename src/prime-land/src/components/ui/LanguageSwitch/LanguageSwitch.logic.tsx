// Copyright (c) 2024 - Jun Dev. All rights reserved

import { LanguageCode } from '../../../redux/slices/languageSlice';

export interface LanguageItem {
  srcImage: string;
  title: string;
  code: LanguageCode;
}

export const languageCodeList: readonly LanguageItem[] = Object.freeze([
  {
    srcImage: '/images/flags/vi.png',
    title: 'navbar_lang_vi',
    code: LanguageCode.Vietnam,
  },
  {
    srcImage: '/images/flags/usa.png',
    title: 'navbar_lang_en',
    code: LanguageCode.English,
  },
]);
