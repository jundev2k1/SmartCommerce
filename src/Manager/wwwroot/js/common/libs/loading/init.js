"use strict";
// Copyright (c) 2024 - Jun Dev. All rights reserved
const GLOBAL_LOADING_CLASS = 'global-loading';
const GLOBAL_LOADING_SELECTOR = 'global-scope';
/**
 * Page show loading (default: fullscreen, area if has selector)
 * @param type {TypeLoading} Type loading (spinner | bar | text)
 * @param selector {string} Target show loading selector (default: fullscreen)
 */
const showLoading = function (type = TypeLoading.spinner, selector = GLOBAL_LOADING_SELECTOR) {
    const element = document.querySelector(selector) || null;
    if (!element) {
        // Create loading element
        const loadingElement = document.createElement('div');
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
        const overlay = document.createElement("div");
        overlay.classList.add(GLOBAL_LOADING_CLASS);
        overlay.appendChild(loadingElement);
        // Append DOM tree
        document.body.appendChild(overlay);
        return;
    }
    // Handle with target area
    if (element) {
        const loadingElement = document.createElement("div");
        loadingElement.classList.add(type);
        element.appendChild(loadingElement);
    }
};
/**
 * Hide loading (default: clear all, clear local if has selector)
 * @param {string} selector String selector (Default: global)
 * @param {TypeClearLoading} type Clear loading type
 */
const hideLoading = function (selector = GLOBAL_LOADING_SELECTOR, type = TypeClearLoading.global) {
    const onClearLoading = (element) => {
        for (const key of Object.keys(TypeLoading)) {
            const itemSelector = `.${key}`;
            const targetElements = element.querySelectorAll(itemSelector);
            targetElements.forEach((item) => item.remove());
        }
    };
    if (type === TypeClearLoading.all) {
        const nodeSelector = document.querySelector('.global-loading');
        nodeSelector && nodeSelector.remove();
        onClearLoading(document);
        return;
    }
    if (type === TypeClearLoading.global) {
        const nodeSelector = document.querySelector('.global-loading');
        nodeSelector && nodeSelector.remove();
        return;
    }
    if (type === TypeClearLoading.target) {
        const targetElement = document.querySelector(selector);
        onClearLoading(targetElement);
        return;
    }
};
