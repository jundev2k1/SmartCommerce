// Navbar customize
const navbarActive = (currentPage) => {
    const navbar = document.querySelector(".nav-bar");
    if (!navbar) return;

    const menuItems = navbar.querySelectorAll(".menu .menu-item");
    menuItems.forEach((menuItem) => {
        if (menuItem.classList.contains("active")) return;

        const subMenuItems = menuItem.querySelectorAll(".sub-menu-item");
        subMenuItems.forEach((subItem) => {
            if (!subItem.classList.contains("active")) return;

            const collapseList = menuItem.querySelector('.collapse');
            if (collapseList.classList.contains("show")) return;
            collapseList.classList.add("show");
        });
    });
};

const resetWidthSidebar = () => {
    const menuItems = document.querySelectorAll('.nav-bar .menu-item .collapse');
    menuItems.forEach((item) => {
        item.classList.add("show");
    });

    const navbar = document.querySelector('.nav-bar');
    const wrapper = document.querySelector('.nav-bar .wrapper');
    const actualWidth = wrapper.getBoundingClientRect().width;
    navbar.style.width = `${Math.ceil(actualWidth)}px`;
    wrapper.style.width = `${Math.ceil(actualWidth)}px`;

    menuItems.forEach((item) => {
        item.classList.remove("show");
    });
};
