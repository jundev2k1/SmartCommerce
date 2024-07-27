// Copyright (c) 2024 - Jun Dev. All rights reserved

/**
 * Type loading enum (spinner | bar | text)
 */
enum TypeLoading {
	spinner = 'loading-spinner',
	bar = 'loading-bar',
	text = 'loading-text'
}

/**
 * Type clear loading enum (global | all | target)
 */
enum TypeClearLoading {
	global,
	all,
	target
}

/**
 * Show loading - function type
 */
type ShowLoading = (type: TypeLoading, selector: string) => void;

/**
 * Hide loading - function type
 */
type HideLoading = (selector: string, type: TypeClearLoading) => void;
