// Copyright (c) 2024 - Jun Dev. All rights reserved

import axios, { AxiosInstance, InternalAxiosRequestConfig } from 'axios';

// Create axios instance
const apiClient: AxiosInstance = axios.create({
  baseURL: `${process.env.REACT_APP_API_BASE_URL}/api`,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Interceptor to add token to request headers
apiClient.interceptors.request.use((config: InternalAxiosRequestConfig) => {
  const token = '';
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }

  return config;
});

export default apiClient;
