// Copyright (c) 2024 - Jun Dev. All rights reserved

export const GetProductImage = (images = '') =>
  images
    .split(',')
    .map(
      (image) =>
        // `${process.env.REACT_APP_API_BASE_URL}${image}` ||
        '/images/placeholder/no-image-placeholder.jpg',
    );
