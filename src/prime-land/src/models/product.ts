// Copyright (c) 2024 - Jun Dev. All rights reserved

import { ProductDisplayPriceEnum, ProductStatusEnum } from '../enums';
import { IModelBase } from './modelBase';

export interface IProduct extends IModelBase {
  productId: string;
  name: string;
  images: string;
  address1: string;
  address2: string;
  address3: string;
  address4: string;
  price1: number;
  price2: number;
  price3: number;
  displayPrice: ProductDisplayPriceEnum;
  status: ProductStatusEnum;
  size1: number;
  size2: number;
  size3: number;
  takeOverId: string;
  shortDescription: string;
  description: string;
  embeddedLink: string;
  relatedProductId: string;
  categoryId1: string;
  categoryId2: string;
  categoryId3: string;
  categoryId4: string;
  categoryId5: string;
  categoryId6: string;
  categoryId7: string;
  categoryId8: string;
  categoryId9: string;
  categoryId10: string;
}
