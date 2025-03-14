// Copyright (c) 2024 - Jun Dev. All rights reserved

declare var toastr: Toastr;

/**
 * Copy image to clipboard async
 * @param {HTMLImageElement} element DOM Image element
 * @returns A promise type void
 */
export const copyImageToClipboard = async function (element: HTMLImageElement): Promise<void> {
	if (!element || element.tagName !== 'IMG') return;

	// Ensure the image is loaded completely
	const img = new Image();
	img.crossOrigin = 'anonymous';
	img.src = element.src;

	img.onload = async function () {
		// Create a canvas to save the image
		const canvas = document.createElement('canvas');
		canvas.width = img.width;
		canvas.height = img.height;
		const ctx = canvas.getContext('2d');
		if (!ctx) {
			toastr.error('Copy QR Code không thành công');
			return;
		}

		// Draw image
		ctx.drawImage(img, 0, 0);

		// Create blob from canvas
		canvas.toBlob(async function (blob) {
			if (!blob) {
				toastr.error("Copy QR Code không thành công", "Failed to create blob");
				return;
			}

			try {
				// Create ClipboardItem object
				const clipboardItem = new ClipboardItem({ 'image/png': blob });
				await navigator.clipboard.write([clipboardItem]);
				toastr.success('Copy thành công QR Code');
			} catch (error: any) {
				toastr.error("Copy QR Code không thành công");
			}

		}, 'image/png');
	};

	img.onerror = function () {
		console.error('Failed to load image');
	};
}
