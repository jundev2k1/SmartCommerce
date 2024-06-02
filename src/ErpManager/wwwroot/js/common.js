// Loading function
const typeLoading = {
    spinner: 'loading-spinner',
    bar: 'loading-bar',
    text: 'loading-text',
};
const showLoading = function (type, selector = 'global') {
    const isGlobal = (selector === 'global' || document.querySelector(selector) === null) || false;
    if (Object.values(typeLoading).includes(type) === false)
        type = typeLoading.spinner;

    if (isGlobal) {
        // Create loading element
        const loadingElement = document.createElement('div');
        switch (type) {
            case typeLoading.spinner:
                loadingElement.style.width = 'calc(100vw / 20)';
                loadingElement.style.height = 'calc(100vw / 20)';
                break;

            case typeLoading.bar:
                loadingElement.style.width = '20vw';
                loadingElement.style.height = 'calc(20vw / 10)';
                break;

            case typeLoading.text:
                loadingElement.style.width = '165px';
                loadingElement.style.height = '40px';
                break;
        }
        loadingElement.classList.add(type);

        // Create overlay
        const overlay = document.createElement("div");
        overlay.classList.add("global-loading")
        overlay.appendChild(loadingElement);

        // Append DOM tree
        document.body.appendChild(overlay);
    } else {
        const element = document.querySelector(selector);
        if (element) {
            const loadingElement = document.createElement("div");
            loadingElement.className = type;
            element.appendChild(loadingElement);
        }
    }
};
const hideLoading = function (type = 'unknown', selector = 'global') {
    if (Object.values(typeLoading).includes(type) === false || type === 'unknown') {
        const types = Object.values(typeLoading);
        if (selector === 'global') {
            const nodeSelector = document.querySelector('.global-loading');
            (nodeSelector) && (nodeSelector.remove());
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

const callAjax = ({ url, data, contentType = 'application/json; charset=utf-8', dataType = 'json', method = 'POST', onSuccess }) => $.ajax({
    url: url,
    type: method,
    contentType: contentType,
    dataType: dataType,
    data,
    success: (result) => {
        onSuccess?.(result);
    },
    error: function (jqXHR, textStatus, errorThrown) {
        debugger
        console.error('AJAX request failed:', textStatus, errorThrown);
    },
});

const copyImageToClipboard = async function (element) {
    if (!element || element.tagName !== 'IMG') return;

    // Ensure the image is loaded completely
    const img = new Image();
    img.crossOrigin = "anonymous";
    img.src = element.src;

    img.onload = async function () {
        // Create a canvas to save the image
        const canvas = document.createElement("canvas");
        canvas.width = img.width;
        canvas.height = img.height;
        const ctx = canvas.getContext("2d");
        ctx.drawImage(img, 0, 0);

        // Create blob from canvas
        canvas.toBlob(async function (blob) {
            try {
                // Create ClipboardItem object
                const clipboardItem = new ClipboardItem({ "image/png": blob });
                await navigator.clipboard.write([clipboardItem]);
                toastr.success('Copy thành công QR Code');
            } catch (error) {
                toastr.error("Copy QR Code không thành công", error);
            }
        }, "image/png");
    };

    img.onerror = function () {
        console.error("Failed to load image");
    };
}
