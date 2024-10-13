"use strict";
// Copyright (c) 2024 - Jun Dev. All rights reserved
/**
 * Type loading enum (spinner | bar | text)
 */
var TypeLoading;
(function (TypeLoading) {
    TypeLoading["spinner"] = "loading-spinner";
    TypeLoading["bar"] = "loading-bar";
    TypeLoading["text"] = "loading-text";
})(TypeLoading || (TypeLoading = {}));
/**
 * Type clear loading enum (global | all | target)
 */
var TypeClearLoading;
(function (TypeClearLoading) {
    TypeClearLoading[TypeClearLoading["global"] = 0] = "global";
    TypeClearLoading[TypeClearLoading["all"] = 1] = "all";
    TypeClearLoading[TypeClearLoading["target"] = 2] = "target";
})(TypeClearLoading || (TypeClearLoading = {}));
