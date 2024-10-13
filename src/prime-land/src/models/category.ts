// Copyright (c) 2024 - Jun Dev. All rights reserved

import { IModelBase } from './modelBase';

export interface ICategory extends IModelBase {
  categoryId: string;
  categoryName: string;
  avatar: string;
  description: string;
  parentCategoryId: string;
  status: string;
}
