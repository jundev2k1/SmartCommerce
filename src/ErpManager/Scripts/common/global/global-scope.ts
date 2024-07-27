// Copyright (c) 2024 - Jun Dev. All rights reserved

/**
 * Declare module: popper core
 */
declare module '@popperjs/core' {
	const Popper: any;
	export = Popper;
}

/**
 * Language code
 * @type {string}
 */
let languageCode: string = 'en';

/**
 * Mobile flag
 * @type {boolean}
 */
let isMobile: boolean = window.innerWidth < 768;
