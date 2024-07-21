"use strict";
// Copyright (c) 2024 - Jun Dev. All rights reserved
/**
 * Format date time
 * @param {Date} date - Date
 * @param {string} separate - Separate sign (Default: "/")
 * @returns {string} - Date format
 */
var formatDate = function (date, separate) {
    if (separate === void 0) { separate = '/'; }
    var year = date.getFullYear();
    var month = String(date.getMonth() + 1).padStart(2, '0');
    var day = String(date.getDate()).padStart(2, '0');
    return year + separate + month + separate + day;
};
//# sourceMappingURL=datetime-utility.js.map