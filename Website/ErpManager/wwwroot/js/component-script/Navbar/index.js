import * as common from '../../common.js';

// Navbar customize
export const navbarActive = (currentPage) => {
    debugger
    const navbar = document.querySelector(".nav-bar");

    if (!navbar) return;

    const menu = navbar.querySelectorAll(".menu .menu-item");
    menu.forEach((item) => {
        if (item.classList.includes("active"));
    });
};