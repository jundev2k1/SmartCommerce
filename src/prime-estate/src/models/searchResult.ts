// Copyright (c) 2024 - Jun Dev. All rights reserved

import { IProduct } from './product';

export interface ISearchResult<T> {
  items: T[];
  totalRecord: number;
  totalPage: number;
}
