// Global variation
let languageCode = 'en';

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
    if (minitorWidth < 768) window.location.reload();
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
import '../lib/select2/js/i18n/vi.js';
import '../lib/select2/js/i18n/en.js';
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

    // For switch navbar
    handleSwitchNavbar();
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
        }
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
    });
}
