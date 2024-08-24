// Copyright (c) 2024 - Jun Dev. All rights reserved

import {
  getProductByCriteria,
  getProductByCriteriaRequest,
} from '../../../api';
import { useApiService } from '../../../components';
import { IProduct, ISearchResult } from '../../../models';

export const useProject = () => {
  const { data, isLoading } = useApiService<
    getProductByCriteriaRequest,
    ISearchResult<IProduct>
  >(getProductByCriteria, { pageIndex: '1', pageSize: '3' });

  return {
    isLoading,
    data,
  };
};
