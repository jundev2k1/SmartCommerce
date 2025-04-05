// Copyright (c) 2025 - Jun Dev. All rights reserved
export const validateConfig = {
    rules: {
        parentID: {
            required: true,
            minlength: 3,
            maxlength: 3,
        },
        categoryID: {
            required: true,
            minlength: 3,
            maxlength: 3,
        }
    },
    messages: {
        parentID: {
            required: localizer['ErrorMsg_IsRequired'],
            minlength: localizer['ErrorMsg_MaxLength'].replaceAll('{MaxLength}', '3'),
            maxlength: localizer['ErrorMsg_MaxLength'].replaceAll('{MaxLength}', '3'),
        },
        categoryID: {
            required: localizer['ErrorMsg_IsRequired'],
            minlength: localizer['ErrorMsg_MaxLength'].replaceAll('{MaxLength}', '3'),
            maxlength: localizer['ErrorMsg_MaxLength'].replaceAll('{MaxLength}', '3'),
        }
    },
    errorPlacement: function (error, element) {
        element.parent().find('.error-message').html(error.html());
    },
    onkeyup: false,
};
