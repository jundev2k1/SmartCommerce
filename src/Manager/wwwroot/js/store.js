// Copyright (c) 2024 - Jun Dev. All rights reserved

// Store js: callback function list (for main layout scroll)
const StoreMainLayoutScrollCallback = [];

// Store js: callback function list (for window load)
const StoreWindowLoadCallback = [];

// Store js: callback function list (for window resize)
const StoreWindowResizeCallback = [];

// Global variable
let languageCode = 'en';
let isMobile = window.innerWidth < 768;