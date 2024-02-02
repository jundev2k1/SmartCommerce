// Loading function
export const typeLoading = {
    spinner: 'loading-spinner',
    bar: 'loading-bar',
    text: 'loading-text',
};
export const showLoading = function (type, selector = 'global') {
    const isGlobal = (selector === 'global'|| document.querySelector(selector) === null) || false;

    if (Object.values(typeLoading).includes(type) === false)
        type = typeLoading.spinner;

    if (isGlobal) {
        const element = document.createElement('div');
        element.style.position = 'fixed';
        switch (type) {
            case typeLoading.spinner:
                element.style.width = 'calc(100vw / 20)';
                element.style.height = 'calc(100vw / 20)';
                break;

            case typeLoading.bar:
                element.style.width = '20vw';
                element.style.height = 'calc(20vw / 10)';
                break;

            case typeLoading.text:
                element.style.width = '165px';
                element.style.height = '40px';
                break;
        }

        element.className = type;
        document.body.appendChild(element);
    } else {
        const element = document.querySelector(selector);
        if (element) {
            const loadingElement = document.createElement("div");
            loadingElement.className = type;
            element.appendChild(loadingElement);
        }
    }
};
export const hideLoading = function (type = 'unknown', selector = 'global') {
    if (Object.values(typeLoading).includes(type) === false || type === 'unknown') {
        const types = Object.values(typeLoading);
        if (selector === 'global') {
            types.forEach((typeItem) => {
                const typeClass = `.${typeItem}`;
                const nodeSelector = document.querySelector(typeClass);

                (nodeSelector) && (nodeSelector.remove());
            });
        }
    } else {
        const typeClass = `.${type}`;
        if (selector === 'global') {
            const element = document.querySelector(typeClass);
            (element) && (element.remove());
        }
        else {
            const element = document.querySelector(selector).querySelector(typeClass);
            (element) && (element.remove());
        }
    }
};
