// Copyright (c) 2024 - Jun Dev. All rights reserved

import { useEffect, useState } from 'react';

interface ApiState<TResponse> {
  data: TResponse | null;
  isLoading: boolean;
  error: Error | null;
}

export const useApiService = <TRequest, TResponse>(
  apiService: (request?: TRequest) => Promise<TResponse>,
  params?: TRequest,
  defaultValue?: TResponse[] | null,
  isInitExecute = true,
) => {
  const [executeState, setExecuteState] = useState(0);
  const [state, setState] = useState<ApiState<TResponse>>({
    data: null,
    error: null,
    isLoading: false,
  });

  useEffect(() => {
    if (!isInitExecute && executeState === 0) return;

    (async () => {
      setState({ data: null, error: null, isLoading: true });
      try {
        const response = await apiService(params);

        setState({
          data: response as TResponse,
          error: null,
          isLoading: false,
        });
      } catch (error) {
        setState({ data: null, error: error as Error, isLoading: false });
      }
    })();
  }, [apiService, executeState]);

  const execute = () => setExecuteState(executeState + 1);

  return { ...state, execute };
};
