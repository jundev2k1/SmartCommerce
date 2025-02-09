// Copyright (c) 2024 - Jun Dev. All rights reserved
/**
 * Format date time
 * @param {Date} date - Date
 * @param {string} separate - Separate sign (Default: "/")
 * @returns {string} - Date format
 */
export const formatDate = (date, separate = '/') => {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    return year + separate + month + separate + day;
};
