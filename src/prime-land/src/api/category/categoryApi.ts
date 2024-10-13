// Copyright (c) 2024 - Jun Dev. All rights reserved

import { ICategory, ISearchResult } from '../../models';
import apiClient from '../apiClient';

const targetApi = '/Category';

export interface getCategoryByCriteriaRequest {
  branchId?: string;
  categoryId?: string;
  pageIndex?: string;
  pageSize?: string;
}
export const getCategoryByCriteria = async (
  request?: getCategoryByCriteriaRequest,
): Promise<ISearchResult<ICategory>> => {
  const defaultRequest: getCategoryByCriteriaRequest = {
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

export interface getAllRootCategoriesRequest {
  branchId: string;
}
export const getAllRootCategories = async (
  request?: getAllRootCategoriesRequest,
): Promise<ICategory[]> => {
  const response = await apiClient.get(`${targetApi}/getAllRootCategories`, {
    params: request,
  });
  return response.data;
};

export interface getCategoryRequest {
  branchId: string;
  categoryId: string;
}
export const getCategory = async (
  request: getCategoryRequest,
): Promise<ICategory> => {
  const response = await apiClient.get(`${targetApi}/get`, { params: request });
  return response.data;
};
