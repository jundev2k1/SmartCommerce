// Navbar customize
const navbarActive = (currentPage) => {
    const navbar = document.querySelector(".nav-bar");
    if (!navbar) return;

    const menuItems = navbar.querySelectorAll(".menu .menu-item");
    menuItems.forEach((menuItem) => {
        if (menuItem.classList.contains("active")) return;

        const subMenuItems = menuItem.querySelectorAll(".sub-menu-item");
        subMenuItems.forEach((subItem) => {
            if (!subItem.classList.contains("active")) continue;

            const collapseList = menuItem.querySelector('.collapse');
            if (collapseList.classList.contains("show")) continue;
            collapseList.classList.add("show");
        });
    });
};
