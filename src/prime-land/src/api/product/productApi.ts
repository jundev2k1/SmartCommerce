// Copyright (c) 2024 - Jun Dev. All rights reserved

import { IProduct, ISearchResult } from '../../models';
import apiClient from '../apiClient';

const targetApi = '/Product';

export interface getProductByCriteriaRequest {
  branchId?: string;
  productId?: string;
  pageIndex?: string;
  pageSize?: string;
}
export const getProductByCriteria = async (
  request?: getProductByCriteriaRequest,
): Promise<ISearchResult<IProduct>> => {
  const defaultRequest: getProductByCriteriaRequest = {
    branchId: '0',
  };

  let params = null;
  let requestData = null;
  if (request) {
    const { pageIndex = '1', pageSize = '20', ...req } = request;
    params = { pageIndex, pageSize };
    requestData = req;
  }

  const response = await apiClient.post(
    `${targetApi}/getByCriteria`,
    { ...defaultRequest, ...requestData },
    {
      params: params,
    },
  );
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
