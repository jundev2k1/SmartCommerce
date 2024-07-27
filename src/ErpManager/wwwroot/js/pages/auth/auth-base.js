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
import { AppBase } from '../../app-base.js';
/**
 * Authentication base
 * @class
*/
var AuthBase = /** @class */ (function (_super) {
    __extends(AuthBase, _super);
    function AuthBase() {
        // Initialize page base
        return _super.call(this) || this;
    }
    return AuthBase;
}(AppBase));
//# sourceMappingURL=auth-base.js.map