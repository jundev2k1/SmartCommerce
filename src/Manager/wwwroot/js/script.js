// Copyright (c) 2024 - Jun Dev. All rights reserved

import '../lib/select2/js/i18n/vi.js';
import '../lib/select2/js/i18n/en.js';

// Handle common page load
document.addEventListener('DOMContentLoaded', () => {
	const mainLayout = document.querySelector("#page-load .render-content");
	if (mainLayout) {
		// Handle main layout scroll
		mainLayout.onscroll = (event) => {
			// Execute main layout callback
			StoreMainLayoutScrollCallback.forEach((callback) => {
				callback?.(event);
			});
		};
	}

	// Handle window load
	StoreWindowLoadCallback.forEach((callback) => {
		callback?.();
	});

	// Handle window resize
	window.onresize = (event) => StoreWindowResizeCallback.forEach((callback) => {
		callback?.(event);
	});

	// Hide loading after pageload
	hideLoading();
});

// Handle reload page when resize to Mobile
const handleResizeForMobileLayout = (event) => {
	const minitorWidth = event.target.innerWidth;
	if (minitorWidth < 768) {
		isMobile = true;
		window.location.reload();
		return;
	}

	isMobile = false;
};
StoreWindowResizeCallback.push(handleResizeForMobileLayout);

// Get language code
(function initLanguageCode() {
	const languageCookie = document.cookie?.split(';').find(cookie => cookie.trim().startsWith(".AspNetCore.Culture"));
	if (!languageCookie) return;

	const decodedString = decodeURIComponent(languageCookie);
	const culture = decodedString.split('=').pop();
	languageCode = culture.split('-')[0];
})();

// Setting default toastr
toastr.options = {
	"closeButton": false,
	"newestOnTop": false,
	"progressBar": true,
	"positionClass": "toast-top-right",
	"preventDuplicates": false,
	"onclick": null,
	"showDuration": "300",
	"hideDuration": "1000",
	"timeOut": "5000",
	"extendedTimeOut": "1000",
	"showEasing": "swing",
	"hideEasing": "linear",
	"showMethod": "fadeIn",
	"hideMethod": "fadeOut"
};

// Handle load select2
$(document).ready(function () {
	const defaultOptions = {
		theme: 'bootstrap-5',
		containerCssClass: 'form-select',
		language: languageCode,
	};

	// For select search input
	$('.select-search-input').select2(defaultOptions);
	handleInitForAddressInput(defaultOptions);
	handleInitForUserInput(defaultOptions);
	handleUploadImage();

	// For switch navbar
	handleSwitchNavbar();

	// Handle load Ck-editor
	handleLoadEditor();
});

const handleInitForAddressInput = (defaultOptions) => {
	let keyValue = '';
	switch (languageCode) {
		case 'en':
			keyValue = 'englishName';
			break;

		case 'vi':
			keyValue = 'vietnameseName';
	}

	$('.select-search-address-1')?.select2({
		...defaultOptions,
		placeholder: languageCode === 'vi' ? 'Vui lòng chọn' : 'Please choose a value',
		ajax: {
			url: '/common/get-provinces',
			dataType: 'json',
			delay: 250,
			data: (params) => ({
				searchKey: params.term || ''
			}),
			processResults: (data) => ({
				results: data.map((item) => ({
					id: item.provinceId,
					text: item[keyValue],
				}))
			}),
			cache: true
		},
		templateSelection: function (result) {
			const { id, text, element } = result;
			if ((id === '') || (text !== '' || element.text !== '')) return text || element.text;

			const url = '/common/get-provinces';
			const onSuccess = (response) => {
				const data = response.find(address => address.provinceId === id);
				if (!data) return;

				$(element).text(data[keyValue]).trigger('change');
			};
			callAjax({ url, data: { searchKey: id }, method: 'GET', onSuccess });
			return result.text;
		},
	}).on('change', (event) => {
		const districtInput = $(`[data-parent-id="${event.target.id}"]`);
		districtInput.val('').change();

		districtInput.each((index, item) => {
			$(`[data-parent-id="${item.id}"]`).val('').change();
		});
	});

	$('.select-search-address-2')?.select2({
		...defaultOptions,
		placeholder: languageCode === 'vi' ? 'Vui lòng chọn' : 'Please choose a value',
		ajax: {
			url: '/common/get-districts',
			dataType: 'json',
			delay: 250,
			data: function (params) {
				const parentElementId = this.data('parentId');
				const parentId = parentElementId ? document.querySelector(`#${parentElementId}`)?.value : '';
				return ({
					searchKey: params.term || '',
					provinceId: parentId || '',
				})
			},
			processResults: (data) => ({
				results: data.map((item) => ({
					id: item.districtId,
					text: item[keyValue],
				}))
			}),
			cache: true
		},
		templateSelection: function (result) {
			const { id, text, element } = result;
			if ((id === '') || (text !== '' || element.text !== '')) return text || element.text;

			const url = '/common/get-districts';
			const onSuccess = (response) => {
				const data = response.find(address => address.districtId === id);
				if (!data) return;

				$(element).text(data[keyValue]).trigger('change');
			};
			callAjax({ url, data: { searchKey: id }, method: 'GET', onSuccess });
			return result.text;
		},
	}).on('change', (event) => {
		const communeInput = $(`[data-parent-id="${event.target.id}"]`);
		communeInput.val('').change();
	});

	$('.select-search-address-3')?.select2({
		...defaultOptions,
		placeholder: languageCode === 'vi' ? 'Vui lòng chọn' : 'Please choose a value',
		ajax: {
			url: '/common/get-communes',
			dataType: 'json',
			delay: 250,
			data: function (params) {
				const parentElementId = this.data('parentId');
				const parentId = parentElementId ? document.querySelector(`#${parentElementId}`)?.value : '';
				return ({
					searchKey: params.term || '',
					districtId: parentId || '',
				})
			},
			processResults: (data) => ({
				results: data.map((item) => ({
					id: item.communeId,
					text: item[keyValue],
				}))
			}),
			cache: true
		},
		templateSelection: function (result) {
			const { id, text, element } = result;
			if ((id === '') || (text !== '' || element.text !== '')) return text || element.text;

			const url = '/common/get-communes';
			const onSuccess = (response) => {
				const data = response.find(address => address.communeId === id);
				if (!data) return;

				$(element).text(data[keyValue]).trigger('change');
			};
			callAjax({ url, data: { searchKey: id }, method: 'GET', onSuccess });
			return result.text;
		},
	});
};

const handleInitForUserInput = (defaultOptions) => {
	$('.select-search-user')?.select2({
		...defaultOptions,
		placeholder: languageCode === 'vi' ? 'Vui lòng chọn' : 'Please choose a value',
		ajax: {
			url: '/common/get-users',
			dataType: 'json',
			delay: 250,
			data: (params) => ({
				searchKey: params.term || '',
			}),
			processResults: (data) => ({
				results: data.map((item) => ({
					id: item.userId,
					text: `${item.userId}. ${item.firstName} ${item.lastName}`,
				})),
			}),
			cache: true
		},
		templateSelection: function (result) {
			const { id, text, element } = result;
			if ((id === '') || (text !== '' || element.text !== '')) return text || element.text;

			const url = '/common/get-users';
			const onSuccess = (response) => {
				const data = response.find(user => user.userId === id);
				if (!data) return;

				$(element).text(`${data.userId}. ${data.firstName} ${data.lastName}`).trigger('change');
			};
			callAjax({ url, data: { searchKey: id }, method: 'GET', onSuccess });
			return result.text;
		},
	});
}

// Handle load datetime picker
import 'https://npmcdn.com/flatpickr/dist/l10n/vn.js';
$(document).ready(function () {
	let config = {};
	switch (languageCode) {
		case 'vi':
			config = {
				locale: 'vn',
				altInput: true,
				altFormat: "j, F, Y",
			};
			break;

		case 'en':
			config = {
				locale: 'default',
				altInput: true,
				altFormat: "F j, Y",
			};
			break;
	}

	$(".datetime-picker").flatpickr(config);
});

const handleSwitchNavbar = () => {
	$('.btn-navbar-switch').on('click', (event) => {
		$('#navBar').fadeToggle('fast', 'linear');
		$('#singleSiteOn').fadeToggle('fast', 'linear');
	});
}

import '../lib/ckeditor5/translations/vi.js';
const handleLoadEditor = () => {
	$('#form-editor').each((index, element) => {
		const targetInputSelector = $(element).data('target-selector');
		const editorKey = $(element).data('editor-key');

		window.editor = {};
		ClassicEditor
			.create(element, { language: languageCode, mediaEmbed: { previewsInData: true } })
			.then(editor => {
				const targetInput = $(targetInputSelector);
				if (targetInput) {
					// Set initial value
					const initData = targetInput?.val();
					if (initData) {
						editor.setData(initData);
					}

					// Set onchange event
					editor.model.document.on('change:data', () => {
						const data = editor.getData();
						targetInput.val(data);
					});
				}
				if (editorKey) {
					window.editor[editorKey] = editor;
				}
			})
			.catch(error => {
				console.error(error);
			});
	});

	const handleInitEditor = (editor) => {
		if (inputTargetSelector) {
			$(inputTargetSelector)?.on('change')
		}
	};
};

const handleUploadImage = () => {
	const elements = document.querySelectorAll('.image-upload');
	elements.forEach(element => {
		uploadImage(element).init();
	});
};

const uploadImage = (element) => {
	let isFirstUpload = true;
	const isMultiple = element.attributes['isMultiple'] ? true : false;
	const typeUpload = element.attributes['typeUpload']?.value;
	const formatFileName = element.attributes['fileName']?.value || '';

	const validateConfig = Object.freeze({
		maxSize: 10 * 1024 * 1024,    // 10MB
		allowedType: ['image / jpeg', 'image / jpg', 'image / png'],    // File allowed
	});
	const message = Object.freeze({
		vi: {
			confirmDelete: 'Bạn có chắc sẽ xóa ảnh này không?',
			successDelete: 'Đã xóa thành công',
			successImport: 'Đã thêm thành công',
			errorHandle: 'Đã xảy ra lỗi xử lý, vui lòng thử lại lần nữa...',
			sizeInvalid: `Không thể upload file quá ${validateConfig.maxSize}`,
			typeInvalid: `Định dạng file không hợp lệ, (${validateConfig.allowedType.join(',')})`,
		},
		en: {
			confirmDelete: 'Bạn có chắc sẽ xóa ảnh này không?',
			successDelete: 'Đã xóa thành công',
			successImport: 'Đã thêm thành công',
			errorHandle: 'Đã xảy ra lỗi xử lý, vui lòng thử lại lần nữa...',
		}
	});

	return {
		masterElement: element,
		inputControl: null,
		valueControl: null,
		importControl: null,
		loadImageArea: null,
		previewImage: null,
		textPlaceholder: null,
		isMultiple: isMultiple,
		srcImages: [],
		targetItemIndex: null,
		messageMaster: null,
		validateOption() {
			const result = (!this.masterElement || !this.valueControl || !this.inputControl) === false;
			return result;
		},
		validateFile(files) {
			const errorMessages = [];
			[...files].forEach((file) => {
				if (file.size > validateConfig.maxSize) {
					errorMessages.push(`${file.name} ${this.messageMaster.sizeInvalid}`);
				}

				if (validateConfig.allowedType.includes(file.type)) {
					errorMessages.push(`${file.name} ${this.messageMaster.typeInvalid}`);
				}
			});
			return errorMessages;
		},
		importImage(files) {
			const url = '/common/upload-images';
			const data = {
				files: Array.from(files),
				type: typeUpload,
				uploadFileName: formatFileName,
				isClearTempImages: isFirstUpload
			};
			const onSuccess = (response) => {
				isFirstUpload = false;
				this.setSrcImages(response);
				toastr.success(this.messageMaster.successImport);
				if (this.isMultiple) {
					this.loadMultiple();
					this.resetEvent();
					return;
				}

				this.loadSingle();
				this.resetEvent();
			};
			callAjax({ url, data, type: requestType.formData, onSuccess });
		},
		deleteImage(element) {
			const onSuccess = (response) => {
				if (formatFileName) {
					const updateNewestImageUrl = '/common/update-newest-image';
					const requestData = { type: typeUpload, primaryKey: formatFileName };
					const updateNewestOnSuccess = (response) => {
						this.srcImages = response.split(',');
						toastr.success(this.messageMaster.successDelete);
						this.resetEvent();
					};
					callAjax({ url: updateNewestImageUrl, data: requestData, onSuccess: updateNewestOnSuccess });
				} else {
					this.srcImages.splice(element.itemIndex, 1);
					toastr.success(this.messageMaster.successDelete);
					this.resetEvent();
				};
			};

			const targetItem = this.srcImages[element.itemIndex];
			const url = '/common/delete-image';
			callAjax({ url, data: { filePath: targetItem }, method: 'GET', onSuccess });


		},
		setSrcImages(strImages) {
			const resultArr = strImages.split(",");
			if (formatFileName) {
				this.srcImages = resultArr;
				this.valueControl.value = strImages.trim();
				return;
			}

			const value = [...resultArr, ...this.srcImages].filter(image => image != '');
			this.srcImages = value;
			this.valueControl.value = value.join(',').trim();
		},
		loadSingle() {
		},
		loadMultiple() {
			let items = '';
			this.srcImages.forEach((src) => {
				items += `<li><img class="img-fluid image-upload-item" src="${src}" /></li>`;
			});
			this.loadImageArea.innerHTML = items;
		},
		previewEvent(element) {
			element.addEventListener('mouseover', () => {
				const targetSrc = this.srcImages[element.itemIndex];
				if (this.previewImage.src == targetSrc) return;

				this.targetItemIndex = element.itemIndex;
				$(this.textPlaceholder)?.hide();
				this.previewImage.src = targetSrc;
				$(this.previewImage)?.fadeIn();
			});

			element.addEventListener('mouseleave', () => {
				this.targetItemIndex = null;
				setTimeout(() => {
					if (this.targetItemIndex === null) {
						this.previewImage.src = '';
						$(this.previewImage)?.fadeOut();
						$(this.textPlaceholder)?.fadeIn();
					}
				}, 1500);
			});
		},
		importEvent() {
			this.inputControl.addEventListener('change', (event) => {
				const files = event.target.files;
				const errorMessages = this.validateFile(files);
				if (errorMessages.length > 0) {
					toastr.error(errorMessages.join('\n'));
					return;
				}

				this.importImage(files);

				// Clear file list (use to re-upload this image in next time)
				event.target.value = '';
			});
		},
		deleteEvent(element) {
			element.addEventListener('click', () => {
				if (!confirm(message['vi'].confirmDelete)) return;

				this.deleteImage(element);
			});
		},
		resetEvent() {
			if (!this.isMultiple) {
				this.loadSingle();
				return;
			}

			this.loadMultiple();
			// Reset delete event
			const uploadItems = this.loadImageArea.querySelectorAll('.image-upload-item')
			uploadItems?.forEach((item, index) => {
				item.itemIndex = index;
				this.previewEvent(item);
				this.deleteEvent(item);
			});
		},
		handleInitLoadImages() {
			const initValues = this.valueControl?.value.split(',').filter(path => path != '') ?? [];
			this.srcImages = this.isMultiple ? initValues : [...initValues[0]];
			const url = '/common/get-src-images';
			const onSuccess = (response) => {
				this.srcImages = response.split(',');
				this.resetEvent();
			}
			callAjax({
				url,
				data: { type: typeUpload, filePath: this.srcImages.join(',') },
				type: requestType.formUrl,
				method: 'GET',
				onSuccess
			});
		},
		init() {
			this.inputControl = this.masterElement.querySelector('.file-input');
			this.valueControl = this.masterElement.querySelector('.upload-value');
			this.importControl = this.masterElement.querySelector('.import-image');
			this.loadImageArea = this.masterElement.querySelector('.load-image-area');
			this.previewImage = this.masterElement.querySelector('.preview-image');
			this.textPlaceholder = this.masterElement.querySelector('.image-text-placeholder');
			this.messageMaster = message[languageCode];

			if (this.validateOption() === false) return;

			// Add click to import
			this.importControl.addEventListener('click', () => {
				this.inputControl?.click();
			});
			this.importEvent();
			this.handleInitLoadImages();
		},
	};
};


/**
 * Check number input value
 * @param {HTMLInputElement} element Input element
 */
const checkNumberInputValue = (element) => {
	const maxLength = Number(element.dataset['maxLength'] || 1);

	element.addEventListener('input', (event) => {
		const _this = event.target;
		_this.value = _this.value.replace(/[^0-9.]/g, '');


		if (_this.value.length > maxLength) {
			_this.value = _this.value.slice(0, maxLength);
		}
	});

	element.addEventListener("paste", (event) => {
		event.preventDefault();
		const _this = event.target;

		const pasteData = (event.clipboardData || window.clipboardData).getData("text");
		const sanitizedData = pasteData.replace(/[^0-9.]/g, '').slice(0, maxLength);
		document.execCommand("insertText", false, sanitizedData);
	});
}
StoreWindowLoadCallback.push(() => {
	const targetNumberInputs = document.querySelectorAll('input[type="number"].number-input');
	targetNumberInputs.forEach(elem => checkNumberInputValue(elem));
});
