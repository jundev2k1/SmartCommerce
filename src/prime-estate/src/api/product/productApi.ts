// Copyright (c) 2024 - Jun Dev. All rights reserved

import { IProduct } from '../../models';
import apiClient from '../apiClient';

const targetApi = '/Product';

export interface getProductByCriteriaRequest {
  branchId: string;
  productId?: string;
}
export const getProductByCriteria = async (
  request?: getProductByCriteriaRequest,
): Promise<IProduct[]> => {
  const defaultRequest: getProductByCriteriaRequest = { branchId: '0' };
  const response = await apiClient.get(`${targetApi}/search`, {
    params: { ...defaultRequest, ...request },
  });
  return response.data;
};

export interface getProductRequest {
  branchId: string;
  productId: string;
}
export const getProduct = async (
  request: getProductRequest,
): Promise<IProduct> => {
  const response = await apiClient.get(`${targetApi}/get`, { params: request });
  return response.data;
};
