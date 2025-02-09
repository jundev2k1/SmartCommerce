/* Copyright (c) 2024 - Jun Dev. All rights reserved */

const convertToFormData = (obj: Object): FormData => {
	const formData = new FormData();
	// Add data to form data
	Object.entries(obj).forEach(([key, value]) => {
		if (!value || !Array.isArray(value)) {
			formData.append(key, value);
			return;
		}

		// Handle add each item if input value is array type
		Array.from(value).forEach(item => {
			formData.append(key, item);
		});
	});

	return formData;
};
