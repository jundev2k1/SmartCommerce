// Copyright (c) 2024 - Jun Dev. All rights reserved
import { RoleBase } from '../role-base.js';
import { RoleSettingAction } from '../models/role-setting-model.js';
import { RoleRequestService } from '../../../https/index.js';
/**
 * Role setting page handler
 * @class
 */
class RoleSettingHandler extends RoleBase {
    /**
     * Role setting selector list
     */
    selector = Object.freeze({
        // Tab button selector
        roleInfoTab: '#roleTabs #roleInfoTab',
        roleSettingTab: '#roleTabs #roleSettingTab',
        // Role permission setting selector
        permissions: '#roleSetting .role-wrapper .permission-select-input',
        innerPermissions: '.permission-select-input',
        pageDefaults: '#roleSetting .role-wrapper .default-page-checkbox',
        selectAllPerms: '#roleSetting .role-wrapper .select-all-check',
        innerSelectAllPerms: '.select-all-check',
        buttonCreates: '.form-group-control .btn-create',
        buttonUpdates: '.form-group-control .btn-update',
        permissionGroup: '.accordion-item',
        errorMessage: '#roleSetting .role-error-message'
    });
    /**
     * Role information fields selector
     */
    roleInfoSelector = Object.freeze({
        roleId: '#roleInformation input#roleId',
        name: '#roleInformation input#roleName',
        priority: '#roleInformation input#rolePriority',
        status: '#roleInformation input#roleStatus',
        desc: '#roleInformation textarea#roleDesc',
    });
    /**
     * Class Constructor
    */
    constructor() {
        // Initialize Role Base
        super();
        // Set tab element
        this.btnInfoTab = document.querySelector(this.selector.roleInfoTab);
        this.btnSettingTab = document.querySelector(this.selector.roleSettingTab);
        // Initialize role information selector
        this.roleIdInput = document.querySelector(this.roleInfoSelector.roleId);
        this.roleNameInput = document.querySelector(this.roleInfoSelector.name);
        this.rolePriorityInput = document.querySelector(this.roleInfoSelector.priority);
        this.roleStatusInput = document.querySelector(this.roleInfoSelector.status);
        this.roleDescriptionInput = document.querySelector(this.roleInfoSelector.desc);
        // Set current action status
        this.actionStatus = this.roleIdInput && (this.roleIdInput?.value !== '0')
            ? RoleSettingAction.Update
            : RoleSettingAction.Register;
        // Initialize role permission selector
        this.permissionCheckList = document.querySelectorAll(this.selector.permissions);
        this.selectAllCheckList = document.querySelectorAll(this.selector.selectAllPerms);
        this.pageDefaultRadioList = document.querySelectorAll(this.selector.pageDefaults);
        this.btnCreates = document.querySelectorAll(this.selector.buttonCreates);
        this.btnUpdates = document.querySelectorAll(this.selector.buttonUpdates);
        this.permissionErrorMessage = document.querySelector(this.selector.errorMessage);
    }
    // Declare class local properties
    actionStatus = RoleSettingAction.Register;
    // Tab button
    btnInfoTab;
    btnSettingTab;
    // Role information element
    roleIdInput;
    roleNameInput;
    rolePriorityInput;
    roleStatusInput;
    roleDescriptionInput;
    // Permission element
    permissionCheckList;
    selectAllCheckList;
    pageDefaultRadioList;
    btnCreates;
    btnUpdates;
    permissionErrorMessage;
    /**
     * Initialize
     */
    init() {
        this.handleCheckIsAction();
        this.hideMessage();
        this.setPermissionItemSelectEvent();
        this.setSelectAllChooseEvent();
        this.setCreateEvent();
        this.setUpdateEvent();
    }
    handleCheckIsAction() {
        switch (this.actionStatus) {
            case RoleSettingAction.Register:
                this.btnSettingTab?.classList.add('disabled');
                this.btnUpdates.forEach(element => element.style.display = 'none');
                this.btnCreates.forEach(element => element.style.display = 'block');
                break;
            case RoleSettingAction.Update:
                this.btnSettingTab?.classList.remove('disabled');
                this.btnUpdates.forEach(element => element.style.display = 'block');
                this.btnCreates.forEach(element => element.style.display = 'none');
                break;
        }
    }
    /**
     * Set permission select input handler
     */
    setPermissionItemSelectEvent() {
        const onChangePermission = (event) => {
            // Get group element
            const targetElement = event.target;
            // Get all permission input in group
            const permGroupItems = this.getPermissionGroupItems(targetElement);
            const isAllChecked = Array.from(permGroupItems).every(item => item.checked);
            // Set check status
            const selectAllCheck = this.getTargetSelectAllButton(targetElement);
            selectAllCheck.checked = isAllChecked;
        };
        // Set permission button change event
        this.permissionCheckList.forEach((checkbox) => {
            checkbox.addEventListener('change', onChangePermission);
        });
    }
    /**
     * Set select all input handler
     */
    setSelectAllChooseEvent() {
        const onChangeSelectAll = (event) => {
            const targetButton = event.target;
            const targetGroupItems = this.getPermissionGroupItems(targetButton);
            const isChecked = targetButton.checked;
            // Handle check all permission item
            if (isChecked) {
                targetGroupItems.forEach((permItem) => {
                    permItem.checked = true;
                });
                return;
            }
            // Handle un-checked all inputs if all permission were checked
            const isCheckAll = Array.from(targetGroupItems).every(item => item.checked);
            if (isCheckAll) {
                targetGroupItems.forEach((permItem) => {
                    permItem.checked = false;
                });
            }
        };
        // Set select all button change event
        this.selectAllCheckList.forEach((btnSelectAll) => {
            btnSelectAll.addEventListener('change', onChangeSelectAll);
        });
    }
    /**
     * Set update button handler
     */
    setCreateEvent() {
        const onRequestSuccess = (response) => {
            this.actionStatus = RoleSettingAction.Update;
            this.btnCreates.forEach(element => element.style.display = 'none');
            this.btnUpdates.forEach(element => element.style.display = 'block');
            this.btnSettingTab?.classList.remove('disabled');
            this.btnSettingTab?.click();
            console.log(response);
        };
        const onCreate = (event) => {
            if (this.actionStatus === RoleSettingAction.Update) {
                event.preventDefault();
                location.reload();
                return;
            }
            const targetElement = event.target;
            this.createUpdateRoleInfo(onRequestSuccess);
            this.showMessage('This is my error message');
        };
        // Add click event
        this.btnCreates.forEach((button) => {
            button.addEventListener('click', onCreate);
        });
    }
    /**
     * Set update button handler
     */
    setUpdateEvent() {
        const onRequestSuccess = (response) => {
            console.log(response);
        };
        const onUpdate = (event) => {
            if (this.actionStatus === RoleSettingAction.Register) {
                event.preventDefault();
                location.reload();
                return;
            }
            const targetElement = event.target;
            this.createUpdateRoleInfo(onRequestSuccess);
            this.showMessage('This is my error message');
        };
        // Add click event
        this.btnUpdates.forEach((button) => {
            button.addEventListener('click', onUpdate);
        });
    }
    /**
     * Create role information request
     */
    createRoleInfoRequest() {
        const result = {
            roleId: Number(this.roleIdInput?.value),
            name: this.roleNameInput?.value || '',
            priority: Number(this.rolePriorityInput?.value),
            status: Number(this.roleStatusInput?.value),
            description: this.roleDescriptionInput?.value || '',
        };
        return result;
    }
    /**
     * Update role info
     */
    createUpdateRoleInfo(onSuccess) {
        const request = this.createRoleInfoRequest();
        RoleRequestService.updateRoleInfo(request, onSuccess);
    }
    /**
     * Hide page message
     */
    hideMessage() {
        this.permissionErrorMessage.innerHTML = '';
        this.permissionErrorMessage.style.display = 'none';
    }
    /**
     * Show message
     * @param {string} message
     */
    showMessage(message = '') {
        if (!message) {
            this.hideMessage();
            return;
        }
        this.permissionErrorMessage.innerHTML = message;
        this.permissionErrorMessage.style.display = 'block';
    }
    /**
     * Get target group (accordion item)
     * @param element Inner elements of the group
     * @returns {HTMLInputElement} Group element
     */
    getTargetGroup(element) {
        const result = element.closest(this.selector.permissionGroup);
        return result;
    }
    /**
     * Get select all input element
     * @param element Inner elements of the group (inner element of the accordion item)
     * @returns {HTMLInputElement} Select all input element
     */
    getTargetSelectAllButton(element) {
        const targetGroup = this.getTargetGroup(element);
        const result = targetGroup
            .querySelector(this.selector.innerSelectAllPerms);
        return result;
    }
    /**
     * Get all input permissions in a target group
     * @param element Inner elements of the group (inner element of the accordion item)
     * @returns {NodeListOf<HTMLInputElement>} All input permissions in the target group
     */
    getPermissionGroupItems(element) {
        const targetGroup = this.getTargetGroup(element);
        const result = targetGroup
            .querySelectorAll(this.selector.innerPermissions);
        return result;
    }
}
// Execute role setting handler
StoreWindowLoadCallback.push(() => new RoleSettingHandler().init());
