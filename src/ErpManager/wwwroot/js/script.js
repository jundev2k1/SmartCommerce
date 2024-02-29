// Global variation
let languageCode = 'en';

// Setting default toastr
toastr.options = {
    "closeButton": true,
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
}

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

    // Hide loading after pageload
    hideLoading();
});

// Get language code
const getLanguageCode = (() => {
    const languageCookie = document.cookie?.split(';').find(cookie => cookie.trim().startsWith(".AspNetCore.Culture"));
    if (!languageCookie) return;

    const decodedString = decodeURIComponent(languageCookie);
    const culture = decodedString.split('=').pop();
    languageCode = culture.split('-')[0];

})();

// Handle load select2
import '../lib/select2/js/i18n/vi.js';
import '../lib/select2/js/i18n/en.js';
$(document).ready(function () {

    const defaultOptions = {
        theme: 'bootstrap-5',
        containerCssClass: 'form-select',
        language: languageCode,
    };

    $('.select-search-input').select2(defaultOptions);

    handleInitForAddressInput(defaultOptions);
    handleAfterAddressInputChange();
});

const handleInitForAddressInput = (defaultOptions) => {
    let valueKey = '';
    switch (languageCode) {
        case 'en':
            valueKey = 'englishName';
            break;

        case 'vi':
            valueKey = 'vietnameseName';
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
                    text: item[valueKey],
                }))
            }),
            cache: true
        }
    })

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
                    text: item[valueKey],
                }))
            }),
            cache: true
        }
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
                    text: item[valueKey],
                }))
            }),
            cache: true
        }
    });
};

const handleAfterAddressInputChange = () => {
    $('.select-search-address-1').on('change', (event) => {
        const districtInput = $(`[data-parent-id="${event.target.id}"]`);
        districtInput.val('').change();

        districtInput.each((index, item) => {
            $(`[data-parent-id="${item.id}"]`).val('').change();
        });
    });

    $('.select-search-address-2').on('change', (event) => {
        const communeInput = $(`[data-parent-id="${event.target.id}"]`);
        communeInput.val('').change();
    });
};

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

    $(".datetime-picker").each((index, item) => {
        $(item).flatpickr(config);
    });
});
