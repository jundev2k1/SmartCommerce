// Copyright (c) 2024 - Jun Dev. All rights reserved

export interface MetaConfigItem {
  title: string;
  description: string;
}

export type MetaConfigType = {
  [key: string]: MetaConfigItem;
};

export const metaConfig: MetaConfigType = Object.freeze({
  home: {
    title: 'meta_home_title',
    description: 'meta_home_desc',
  },
  project: {
    title: '',
    description: '',
  },
  about: {
    title: '',
    description: '',
  },
});
