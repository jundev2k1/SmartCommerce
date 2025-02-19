// Copyright (c) 2024 - Jun Dev. All rights reserved

/**
 * Takes the first `n` elements from the array.
 * @param {number} n - Number of elements to take.
 * @returns {Array} A new array containing the first `n` elements.
 */
Array.prototype.take = function (n) {
	if (n < 0) {
		throw new Error("Number of elements to take must be non-negative");
	}
	return this.slice(0, n);
};
/**
 * Skips the first `n` elements of the array.
 * @param {number} n - Number of elements to skip.
 * @returns {Array} A new array containing all elements after the first `n` elements.
 */
Array.prototype.skip = function (n) {
	if (n < 0) {
		throw new Error("Number of elements to skip must be non-negative");
	}
	return this.slice(n);
};
/**
 * Splits the array into chunks of the specified size.
 * @param {number} size - Size of each chunk.
 * @returns {Array<Array>} A new array containing arrays of the specified size.
 */
Array.prototype.chunk = function (size) {
	if (size <= 0) {
		throw new Error("Chunk size must be greater than zero");
	}
	const result = [];
	for (let i = 0; i < this.length; i += size) {
		result.push(this.slice(i, i + size));
	}
	return result;
};

const convertToFormData = (data) => {
	const formData = new FormData();
	// Check params
	if (typeof data !== 'object') return formData;

	// Add data to form data
	Object.entries(data).forEach(([key, value]) => {
		if (!value) return;

		if (Array.isArray(value)) {
			Array.from(value).forEach(item => {
				formData.append(key, item);
			});
			return;
		}

		formData.append(key, value);
	});

	return formData;
};

const requestType = Object.freeze({
	json: 'json',
	formUrl: 'formUrl',
	formData: 'formData',
	textPlain: 'textPlain'
});

// Content type
const requestContentType = Object.freeze({
	json: 'application/json; charset=utf-8',
	formUrlEncoded: 'application/x-www-form-urlencoded',
	formData: false,
	textPlain: 'text/plain'
});

const createRequestOption = ({ data, type = requestType.json }) => {
	const options = {
		json: {
			data: JSON.stringify(data),
			contentType: requestContentType.json,
			dataType: 'json'
		},
		formUrl: {
			data: new URLSearchParams(data).toString(),
			contentType: requestContentType.formUrlEncoded,
		},
		formData: {
			data: convertToFormData(data),
			contentType: requestContentType.formData,
			processData: false,
		},
		textPlain: {
			data: data,
			contentType: requestContentType.textPlain,
		}
	};
	return options[type];
};

// Loading function
const typeLoading = {
	spinner: 'loading-spinner',
	bar: 'loading-bar',
	text: 'loading-text',
};
const showLoading = function (type, selector = 'global') {
	const isGlobal = (selector === 'global' || document.querySelector(selector) === undefined) || false;
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

const callAjax = ({ url, data, type = requestType.json, method = 'POST', onSuccess }) => $.ajax({
	url: url,
	type: method,
	...createRequestOption({ data, type }),
	success: (result) => {
		onSuccess?.(result);
	},
	error: function (jqXHR, textStatus, errorThrown) {
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

/**
 * Redirect page
 * @param {string} url Redirect URL
 */
const redirectPage = (url = '/') => {
	window.location.href = url;
}
