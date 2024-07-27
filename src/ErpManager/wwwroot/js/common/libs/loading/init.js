"use strict";
// Copyright (c) 2024 - Jun Dev. All rights reserved
var GLOBAL_LOADING_CLASS = 'global-loading';
var GLOBAL_LOADING_SELECTOR = 'global-scope';
/**
 * Page show loading (default: fullscreen, area if has selector)
 * @param type {TypeLoading} Type loading (spinner | bar | text)
 * @param selector {string} Target show loading selector (default: fullscreen)
 */
var showLoading = function (type, selector) {
    if (type === void 0) { type = TypeLoading.spinner; }
    if (selector === void 0) { selector = GLOBAL_LOADING_SELECTOR; }
    var element = document.querySelector(selector) || null;
    if (!element) {
        // Create loading element
        var loadingElement = document.createElement('div');
        switch (type) {
            case TypeLoading.spinner:
                loadingElement.style.width = 'calc(100vw / 20)';
                loadingElement.style.height = 'calc(100vw / 20)';
                break;
            case TypeLoading.bar:
                loadingElement.style.width = '20vw';
                loadingElement.style.height = 'calc(20vw / 10)';
                break;
            case TypeLoading.text:
                loadingElement.style.width = '165px';
                loadingElement.style.height = '40px';
                break;
        }
        loadingElement.classList.add(type);
        // Create overlay
        var overlay = document.createElement("div");
        overlay.classList.add(GLOBAL_LOADING_CLASS);
        overlay.appendChild(loadingElement);
        // Append DOM tree
        document.body.appendChild(overlay);
        return;
    }
    // Handle with target area
    if (element) {
        var loadingElement = document.createElement("div");
        loadingElement.classList.add(type);
        element.appendChild(loadingElement);
    }
};
/**
 * Hide loading (default: clear all, clear local if has selector)
 * @param {string} selector String selector (Default: global)
 * @param {TypeClearLoading} type Clear loading type
 */
var hideLoading = function (selector, type) {
    if (selector === void 0) { selector = GLOBAL_LOADING_SELECTOR; }
    if (type === void 0) { type = TypeClearLoading.global; }
    var onClearLoading = function (element) {
        for (var _i = 0, _a = Object.keys(TypeLoading); _i < _a.length; _i++) {
            var key = _a[_i];
            var itemSelector = ".".concat(key);
            var targetElements = element.querySelectorAll(itemSelector);
            targetElements.forEach(function (item) { return item.remove(); });
        }
    };
    if (type === TypeClearLoading.all) {
        var nodeSelector = document.querySelector('.global-loading');
        nodeSelector && nodeSelector.remove();
        onClearLoading(document);
        return;
    }
    if (type === TypeClearLoading.global) {
        var nodeSelector = document.querySelector('.global-loading');
        nodeSelector && nodeSelector.remove();
        return;
    }
    if (type === TypeClearLoading.target) {
        var targetElement = document.querySelector(selector);
        onClearLoading(targetElement);
        return;
    }
};
//# sourceMappingURL=init.js.map