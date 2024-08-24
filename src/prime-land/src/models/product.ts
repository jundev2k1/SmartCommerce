// Copyright (c) 2024 - Jun Dev. All rights reserved

import { ProductDisplayPriceEnum, ProductStatusEnum } from '../enums';

export interface IProduct {
  branchId: string;
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
  delFlg: boolean;
  size1: number;
  size2: number;
  size3: number;
  takeOverId: string;
  description: string;
  embeddedLink: string;
  relatedProductId: string;
  dateCreated: Date;
  dateChanged: Date;
  createdBy: string;
  lastChanged: string;
}
