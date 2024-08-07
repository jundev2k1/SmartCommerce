// Copyright (c) 2024 - Jun Dev. All rights reserved

export const removeVietnameseSign = (text: string) => {
  return text.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
};

export const capitalizeFirstLetters = (text: string) => {
  return text.replace(/\b\w/g, (match) => match.toUpperCase());
};

export const formatCurrency = (number: number) => {
  return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
};
