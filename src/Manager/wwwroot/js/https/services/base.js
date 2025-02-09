// Copyright (c) 2024 - Jun Dev. All rights reserved
import { RequestMethod, RequestType } from './base-model.js';
/**
 * Service base
 */
export class ServiceBase {
    constructor() {
    }
    /**
     * Call request action
     * @param {BodyRequest} request
     */
    static callRequest(request) {
        // Get and set default request data
        const { endpoint, data, type = RequestType.Json, method = RequestMethod.Post, onSuccess, onError, } = request;
        // Use default if onError not set
        const onErrorDefault = function (jqXHR, textStatus, errorThrown) {
            console.error('AJAX request failed:', textStatus, errorThrown);
        };
        $.ajax({
            url: endpoint,
            type: method,
            ...this.createBodyRequest(data, type),
            success: (result) => {
                onSuccess?.(result);
            },
            error: (!onError) ? onErrorDefault : onError,
        });
    }
    /**
     * Request content type
     */
    static requestContentType = Object.freeze({
        [RequestType.Json]: 'application/json; charset=utf-8',
        [RequestType.FormUrlEncoded]: 'application/x-www-form-urlencoded',
        [RequestType.FormData]: false,
        [RequestType.TextPlain]: 'text/plain'
    });
    /**
     * Create Body Request
     * @param data {any} Request data
     * @param type {RequestType} Request type
     * @returns Request body
     */
    static createBodyRequest = (data, type = RequestType.Json) => {
        switch (type) {
            case RequestType.Json:
                return Object.freeze({
                    data: JSON.stringify(data),
                    contentType: this.requestContentType[type],
                    dataType: 'json'
                });
            case RequestType.FormUrlEncoded:
                return Object.freeze({
                    data: new URLSearchParams(data).toString(),
                    contentType: this.requestContentType[type],
                });
            case RequestType.FormData:
                return Object.freeze({
                    data: convertToFormData(data),
                    contentType: this.requestContentType[type],
                    processData: false,
                });
            case RequestType.TextPlain:
                return Object.freeze({
                    data: data,
                    contentType: this.requestContentType[type],
                });
            default:
                throw new DOMException('Request type not exist');
        }
    };
    static requestMethod;
}
