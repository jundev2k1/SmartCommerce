// Copyright (c) 2024 - Jun Dev. All rights reserved

import { ReactNode } from 'react';
import { MetaConfigItem } from '../config';

export interface LayoutProps extends MetaConfigItem {
  children: ReactNode;
}
