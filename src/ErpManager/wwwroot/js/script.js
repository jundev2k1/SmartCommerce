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
