// Copyright (c) 2024 - Jun Dev. All rights reserved

import {
  getAllRootCategories,
  getAllRootCategoriesRequest,
} from '../../../api';
import { useApiService } from '../../../components';
import { ICategory } from '../../../models';

export const useProject = () => {
  const { data, isLoading } = useApiService<
    getAllRootCategoriesRequest,
    ICategory[]
  >(getAllRootCategories, { branchId: '0' });

  return {
    isLoading,
    data,
  };
};
