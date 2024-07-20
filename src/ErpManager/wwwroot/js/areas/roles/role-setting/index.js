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
        // Initialize Role Base
        var _this = _super.call(this) || this;
        _this.selector = Object.freeze({
            permissions: '#roleSetting .role-wrapper .permission-select-input',
            innerPermissions: '.permission-select-input',
            pageDefaults: '#roleSetting .role-wrapper .default-page-checkbox',
            selectAllPerms: '#roleSetting .role-wrapper .select-all-check',
            innerSelectAllPerms: '.select-all-check',
            buttonUpdates: '#roleSetting .role-wrapper .form-submit',
            permissionGroup: '.accordion-item',
            messageBlock: '#roleSetting .page-error-message',
            messageInner: '.error-message',
        });
        // Initialize
        _this.permissionCheckList = document.querySelectorAll(_this.selector.permissions);
        _this.selectAllCheckList = document.querySelectorAll(_this.selector.selectAllPerms);
        _this.pageDefaultRadioList = document.querySelectorAll(_this.selector.pageDefaults);
        _this.btnUpdates = document.querySelectorAll(_this.selector.buttonUpdates);
        return _this;
    }
    /**
     * Initialize class
     */
    RoleSettingHandler.prototype.init = function () {
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
            var isAllChecked = Array.from(permGroupItems).some(function (item) { return !item.checked; }) == false;
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
        var onUpdate = function (event) {
            var targetElement = event.target;
        };
        // Add click event
        this.btnUpdates.forEach(function (button) {
            button.addEventListener('click', onUpdate);
        });
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
//# sourceMappingURL=index.js.map