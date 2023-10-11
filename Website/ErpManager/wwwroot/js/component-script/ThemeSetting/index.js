const modeList = Object.freeze([
    {
        name: "Light mode",
        className: "light-mode",
        color: "--site-bg-light-mode"
    },
    {
        name: "Dark mode",
        className: "dark-mode",
        color: "--site-bg-dark-mode"
    }
]);
const themeList = Object.freeze([
    {
        name: "White theme",
        className: "white-theme",
        color: "--site-white-theme",
    },
    {
        name: "Milky theme",
        className: "milky-theme",
        color: "--site-milky-theme",
    },
    {
        name: "Pastel theme",
        className: "pastel-theme",
        color: "--site-pastel-theme",
    },
    {
        name: "Pink theme",
        className: "pink-theme",
        color: "--site-pink-theme",
    },
    {
        name: "Orange theme",
        className: "orange-theme",
        color: "--site-orange-theme",
    },
    {
        name: "Red theme",
        className: "red-theme",
        color: "--site-red-theme",
    },
    {
        name: "Yellow theme",
        className: "yellow-theme",
        color: "--site-yellow-theme",
    },
    {
        name: "Green theme",
        className: "green-theme",
        color: "--site-green-theme",
    },
    {
        name: "Blue theme",
        className: "blue-theme",
        color: "--site-blue-theme",
    },
]);
const ThemeSetting = (function () {
    // Element selector
    debugger
    const root = document.querySelector("#page-load");
    const contentElement = document.querySelector(".theme-settings");
    const remoteElement = document.querySelector(".btn-theme-settings button");
    const btnClose = contentElement.querySelector("#btnCloseSetting");
    const renderTheme = contentElement.querySelector("#renderThemeSetting");
    const renderMode = contentElement.querySelector("#renderModeSetting");

    // Expires time (1 year)
    const expiresTime = () => {
        const time = new Date();
        time.setFullYear(time.getFullYear() + 1);
        return time;
    }

    // Cookie type
    const type = Object.freeze({
        Mode: "mode",
        Theme: "theme"
    });

    this.currentMode = '';
    this.currentTheme = '';

    return {
        setControl() {
            remoteElement.addEventListener('click', () => this.open());
            btnClose.addEventListener('click', () => this.close());
        },
        refresh() {
            // Get cookies
            this.getCookies();

            // Remove all current setting
            root.className = '';

            // Set value for mode setting
            const mode = modeList.find(item => item.name === this.currentMode);
            (mode)
                ? root.classList.add(mode.className)
                : root.classList.add(modeList[0].className);
            // Set value for theme setting
            const theme = themeList.find(item => item.name === this.currentTheme);
            (theme)
                ? root.classList.add(theme.className)
                : root.classList.add(themeList[0].className);
        },
        getCookies() {
            const cookies = document.cookie?.split(';');
            debugger
            if (cookies !== '') {
                cookies.forEach((cookie) => {
                    const data = cookie.split('=');
                    switch (data[0].trim()) {
                        case type.Mode:
                            this.currentMode = data[1];
                            break;

                        case type.Theme:
                            this.currentTheme = data[1];
                            break;
                    }
                });
            } else {
                this.currentMode = modeList[0].name;
                this.currentTheme = themeList[0].name;
            }
        },
        setCookie(name, value) {
            if (!name || !value) return;

            const cookiePattern = `${name}=${value};expires=${expiresTime()};path=/`;
            document.cookie = cookiePattern;
        },
        renderContent() {
            debugger
            let modeContent = '';
            modeList.forEach((mode, index) => {
                let content = ''
                    + `<li class="setting-item ${(this.currentMode === mode.name) ? "choose" : ""}">`
                    + `<div class="setting-field" data-value="${mode.name}" `
                    + `style="background: var(${mode.color})">`
                    + `<a key="${index}" href="#" onclick="ThemeSetting.choose(event, '${type.Mode}')"><i class="fa-regular fa-check fa-fw"></i></a>`
                    + `</div>`
                    + '</li>';
                modeContent += content;
            });
            renderMode.innerHTML = modeContent;

            let themeContent = '';
            themeList.forEach((theme, index) => {
                let content = ''
                    + `<li class="setting-item ${(this.currentTheme === theme.name) ? "choose" : ""}">`
                    + `<div class="setting-field" data-value="${theme.name}" `
                    + `style="background: var(${theme.color})">`
                    + `<a key="${index}" href="#" onclick="ThemeSetting.choose(event, '${type.Theme}')"><i class="fa-regular fa-check fa-fw"></i></a>`
                    + `</div>`
                    + '</li>';
                themeContent += content;
            });
            renderTheme.innerHTML = themeContent;
        },
        choose(event, typeUpdate) {
            event.preventDefault();
            const parentElement = event.currentTarget.parentNode;
            const data = parentElement.dataset["value"];

            if (data || typeUpdate in type) {
                this.setCookie(typeUpdate, data);
                this.refresh();
                this.renderContent();
                toastr.success(successMessage);
            }
            else {
                toastr.error(errorMessage);
            }
        },
        open() {
            contentElement.classList.add("show");
        },
        close() {
            contentElement.classList.remove("show");
        },
        init() {
            if (remoteElement === null || contentElement === null) return;

            this.refresh();
            this.renderContent();
            this.setControl();
        }
    };
})();
