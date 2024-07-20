"use strict";
/* Copyright (c) 2024 - Jun Dev. All rights reserved */
var convertToFormData = function (obj) {
    var formData = new FormData();
    // Add data to form data
    Object.entries(obj).forEach(function (_a) {
        var key = _a[0], value = _a[1];
        if (!value || !Array.isArray(value)) {
            formData.append(key, value);
            return;
        }
        // Handle add each item if input value is array type
        Array.from(value).forEach(function (item) {
            formData.append(key, item);
        });
    });
    return formData;
};
//# sourceMappingURL=form.js.map