// Copyright (c) 2025 - Jun Dev. All rights reserved

export interface ISearchFormSettingModel {
	btnSearchSelector: string,
	targetSelector: string,
	searchUrl: string,
	defaultParameters: Record<string, string>,
	searchSettings: searchSetting[],
}

export interface searchSetting {
	selector: string,
	requestKey: string,
	getValue?: (element: Element) => string,
}