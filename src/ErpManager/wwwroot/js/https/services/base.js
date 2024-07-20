"use strict";
// Copyright (c) 2024 - Jun Dev. All rights reserved
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var _a;
/**
 * Request Service base
 */
var RequestServiceBase = /** @class */ (function () {
    function RequestServiceBase() {
    }
    /**
     * Call request action
     * @param {BodyRequest} request
     */
    RequestServiceBase.callRequest = function (request) {
        // Get and set default request data
        var endpoint = request.endpoint, data = request.data, _a = request.type, type = _a === void 0 ? RequestType.Json : _a, _c = request.method, method = _c === void 0 ? 'POST' : _c, onSuccess = request.onSuccess, onError = request.onError;
        // Use default if onError not set
        var onErrorDefault = function (jqXHR, textStatus, errorThrown) {
            console.error('AJAX request failed:', textStatus, errorThrown);
        };
        $.ajax(__assign(__assign({ url: endpoint, type: method }, this.createBodyRequest(data, type)), { success: function (result) {
                onSuccess === null || onSuccess === void 0 ? void 0 : onSuccess(result);
            }, error: (!onError) ? onErrorDefault : onError }));
    };
    var _b;
    _b = RequestServiceBase;
    /**
     * Request content type
     */
    RequestServiceBase.requestContentType = Object.freeze((_a = {},
        _a[RequestType.Json] = 'application/json; charset=utf-8',
        _a[RequestType.FormUrlEncoded] = 'application/x-www-form-urlencoded',
        _a[RequestType.FormData] = false,
        _a[RequestType.TextPlain] = 'text/plain',
        _a));
    /**
     * Create Body Request
     * @param data {any} Request data
     * @param type {RequestType} Request type
     * @returns Request body
     */
    RequestServiceBase.createBodyRequest = function (data, type) {
        if (type === void 0) { type = RequestType.Json; }
        switch (type) {
            case RequestType.Json:
                return Object.freeze({
                    data: JSON.stringify(data),
                    contentType: _b.requestContentType[type],
                    dataType: 'json'
                });
            case RequestType.FormUrlEncoded:
                return Object.freeze({
                    data: new URLSearchParams(data).toString(),
                    contentType: _b.requestContentType[type],
                });
            case RequestType.FormData:
                return Object.freeze({
                    data: convertToFormData(data),
                    contentType: _b.requestContentType[type],
                    processData: false,
                });
            case RequestType.TextPlain:
                return Object.freeze({
                    data: data,
                    contentType: _b.requestContentType[type],
                });
            default:
                throw new DOMException('Request type not exist');
        }
    };
    return RequestServiceBase;
}());
//# sourceMappingURL=base.js.map