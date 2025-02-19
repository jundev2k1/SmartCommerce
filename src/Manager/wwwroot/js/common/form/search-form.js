// Copyright (c) 2025 - Jun Dev. All rights reserved
export class SearchFormHandler {
    constructor(setting) {
        this.setting = setting;
    }
    setting;
    getSearchRequest() {
        const request = {};
        Object.entries(this.setting.defaultParameters).forEach(([key, value]) => {
            request[key] = value;
        });
        this.setting.searchSettings.forEach(setting => {
            const targetElement = document.querySelector(`${this.setting.targetSelector} ${setting.selector}`);
            if (!targetElement)
                return;
            request[setting.requestKey] = !setting.getValue
                ? targetElement?.value
                : setting.getValue(targetElement);
        });
        return request;
    }
    /**
     * On search event
     * @param {MouseEvent} event Click event
     */
    onSearch(event) {
        event.preventDefault();
        const queryString = Object.entries(this.getSearchRequest())
            .filter(([key, value]) => value)
            .map(([key, value]) => `${encodeURIComponent(key)}=${encodeURIComponent(value)}`)
            .join('&');
        const url = `${this.setting.searchUrl}?${queryString}`;
        window.location.href = url;
    }
    init() {
        const targetElement = document.querySelector(this.setting.btnSearchSelector);
        if (!targetElement)
            return;
        targetElement.addEventListener('click', (event) => {
            this.onSearch(event);
        });
    }
}
