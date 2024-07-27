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
import { RoleBase } from '../role-base.js';
/**
 * Role setting page handler
 * @class
 */
var RoleSettingHandler = /** @class */ (function (_super) {
    __extends(RoleSettingHandler, _super);
    /**
     * Class Constructor
    */
    function RoleSettingHandler() {
        var _this = 
        // Initialize Role Base
        _super.call(this) || this;
        /**
         * Role setting selector list
         */
        _this.selector = Object.freeze({
            permissions: '#roleSetting .role-wrapper .permission-select-input',
            innerPermissions: '.permission-select-input',
            pageDefaults: '#roleSetting .role-wrapper .default-page-checkbox',
            selectAllPerms: '#roleSetting .role-wrapper .select-all-check',
            innerSelectAllPerms: '.select-all-check',
            buttonUpdates: '#roleSetting .form-submit',
            permissionGroup: '.accordion-item',
            errorMessage: '#roleSetting .role-error-message'
        });
        /**
         * Role setting endpoint
         */
        _this.endpoint = Object.freeze({
            updateInfo: '/role/setting/update-information',
            updateSettings: '/role/setting/update-settings'
        });
        // Initialize
        _this.permissionCheckList = document.querySelectorAll(_this.selector.permissions);
        _this.selectAllCheckList = document.querySelectorAll(_this.selector.selectAllPerms);
        _this.pageDefaultRadioList = document.querySelectorAll(_this.selector.pageDefaults);
        _this.btnUpdates = document.querySelectorAll(_this.selector.buttonUpdates);
        _this.errorMessage = document.querySelector(_this.selector.errorMessage);
        return _this;
    }
    /**
     * Initialize class
     */
    RoleSettingHandler.prototype.init = function () {
        this.hideMessage();
        this.setPermissionItemSelectEvent();
        this.setSelectAllChooseEvent();
        this.setUpdateEvent();
    };
    /**
     * Set permission select input handler
     */
    RoleSettingHandler.prototype.setPermissionItemSelectEvent = function () {
        var _this = this;
        var onChangePermission = function (event) {
            // Get group element
            var targetElement = event.target;
            // Get all permission input in group
            var permGroupItems = _this.getPermissionGroupItems(targetElement);
            var isAllChecked = Array.from(permGroupItems).every(function (item) { return item.checked; });
            // Set check status
            var selectAllCheck = _this.getTargetSelectAllButton(targetElement);
            selectAllCheck.checked = isAllChecked;
        };
        // Set permission button change event
        this.permissionCheckList.forEach(function (checkbox) {
            checkbox.addEventListener('change', onChangePermission);
        });
    };
    /**
     * Set select all input handler
     */
    RoleSettingHandler.prototype.setSelectAllChooseEvent = function () {
        var _this = this;
        var onChangeSelectAll = function (event) {
            var targetButton = event.target;
            var targetGroupItems = _this.getPermissionGroupItems(targetButton);
            var isChecked = targetButton.checked;
            // Handle check all permission item
            if (isChecked) {
                targetGroupItems.forEach(function (permItem) {
                    permItem.checked = true;
                });
                return;
            }
            // Handle un-checked all inputs if all permission were checked
            var isCheckAll = Array.from(targetGroupItems).every(function (item) { return item.checked; });
            if (isCheckAll) {
                targetGroupItems.forEach(function (permItem) {
                    permItem.checked = false;
                });
            }
        };
        // Set select all button change event
        this.selectAllCheckList.forEach(function (btnSelectAll) {
            btnSelectAll.addEventListener('change', onChangeSelectAll);
        });
    };
    /**
     * Set update button handler
     */
    RoleSettingHandler.prototype.setUpdateEvent = function () {
        var _this = this;
        var onUpdate = function (event) {
            var targetElement = event.target;
            _this.updateSettingInfo();
            _this.showMessage('This is my error message');
        };
        // Add click event
        this.btnUpdates.forEach(function (button) {
            button.addEventListener('click', onUpdate);
        });
    };
    RoleSettingHandler.prototype.updateSettingInfo = function () {
        // RequestServiceBase.callRequest();
    };
    /**
     * Hide page message
     */
    RoleSettingHandler.prototype.hideMessage = function () {
        this.errorMessage.innerHTML = '';
        this.errorMessage.style.display = 'none';
    };
    /**
     * Show message
     * @param {string} message
     */
    RoleSettingHandler.prototype.showMessage = function (message) {
        if (message === void 0) { message = ''; }
        if (!message) {
            this.hideMessage();
            return;
        }
        this.errorMessage.innerHTML = message;
        this.errorMessage.style.display = 'block';
    };
    /**
     * Get target group (accordion item)
     * @param element Inner elements of the group
     * @returns {HTMLInputElement} Group element
     */
    RoleSettingHandler.prototype.getTargetGroup = function (element) {
        var result = element.closest(this.selector.permissionGroup);
        return result;
    };
    /**
     * Get select all input element
     * @param element Inner elements of the group (inner element of the accordion item)
     * @returns {HTMLInputElement} Select all input element
     */
    RoleSettingHandler.prototype.getTargetSelectAllButton = function (element) {
        var targetGroup = this.getTargetGroup(element);
        var result = targetGroup
            .querySelector(this.selector.innerSelectAllPerms);
        return result;
    };
    /**
     * Get all input permissions in a target group
     * @param element Inner elements of the group (inner element of the accordion item)
     * @returns {NodeListOf<HTMLInputElement>} All input permissions in the target group
     */
    RoleSettingHandler.prototype.getPermissionGroupItems = function (element) {
        var targetGroup = this.getTargetGroup(element);
        var result = targetGroup
            .querySelectorAll(this.selector.innerPermissions);
        return result;
    };
    return RoleSettingHandler;
}(RoleBase));
// Execute role setting handler
StoreWindowLoadCallback.push(function () { return new RoleSettingHandler().init(); });
//# sourceMappingURL=role-setting-handler.js.map