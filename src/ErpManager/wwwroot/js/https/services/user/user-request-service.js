"use strict";
// Copyright (c) 2024 - Jun Dev. All rights reserved
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
/**
 * User request service
 * @class
 */
var UserRequestService = /** @class */ (function (_super) {
    __extends(UserRequestService, _super);
    function UserRequestService() {
        // Initialize page base
        return _super.call(this) || this;
    }
    return UserRequestService;
}(RequestServiceBase));
exports.default = UserRequestService;
//# sourceMappingURL=user-request-service.js.map