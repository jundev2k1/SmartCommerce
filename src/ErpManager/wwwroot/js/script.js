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
    // Handle window scroll
    window.onscroll = (event) => {
        // Get window callback
        StoreWindowScrollCallback.forEach((callback) => {
            callback?.(event);
        });
    };

    // Handle window load
    StoreWindowLoadCallback.forEach((callback) => {
        callback?.();
    });

    // Hide loading after pageload
    hideLoading();
});
