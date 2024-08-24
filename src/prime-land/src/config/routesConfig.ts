// Copyright (c) 2024 - Jun Dev. All rights reserved
import { metaConfig, MetaConfigItem } from './metaConfig';
import { HomeLayout } from '../layout';
import { LayoutProps } from '../layout/common';
import { HomePage } from '../pages';

interface RouteOptionItem extends MetaConfigItem {
  path: string;
  Layout: (props: LayoutProps) => JSX.Element;
  Page: React.FC;
}

export const routeConfigs: readonly RouteOptionItem[] = Object.freeze([
  {
    ...metaConfig['home'],
    path: '/',
    Layout: HomeLayout,
    Page: HomePage,
  },
]);
