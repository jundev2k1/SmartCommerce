// Copyright (c) 2024 - Jun Dev. All rights reserved

import { RoleBase } from '../role-base';
import { RoleSettingAction } from '../models/role-setting-model';
import { RoleRequestService } from '../../../https/index';
import { OnRequestSuccess } from '../../../https/services/base-model';

/**
 * Role setting page handler
 * @class
 */
class RoleSettingHandler extends RoleBase {
	/**
	 * Role setting selector list
	 */
	private selector = Object.freeze({
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
	private roleInfoSelector = Object.freeze({
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
		this.roleIdInput = document.querySelector<HTMLInputElement>(this.roleInfoSelector.roleId);
		this.roleNameInput = document.querySelector<HTMLInputElement>(this.roleInfoSelector.name);
		this.rolePriorityInput = document.querySelector<HTMLInputElement>(this.roleInfoSelector.priority);
		this.roleStatusInput = document.querySelector<HTMLInputElement>(this.roleInfoSelector.status);
		this.roleDescriptionInput = document.querySelector<HTMLInputElement>(this.roleInfoSelector.desc);

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
		this.permissionErrorMessage = document.querySelector(this.selector.errorMessage) as HTMLDivElement;
	}

	// Declare class local properties
	private actionStatus: RoleSettingAction = RoleSettingAction.Register;
	// Tab button
	private btnInfoTab: HTMLAnchorElement | null;
	private btnSettingTab: HTMLAnchorElement | null;

	// Role information element
	private roleIdInput: HTMLInputElement | null;
	private roleNameInput: HTMLInputElement | null;
	private rolePriorityInput: HTMLInputElement | null;
	private roleStatusInput: HTMLInputElement | null;
	private roleDescriptionInput: HTMLInputElement | null;

	// Permission element
	private permissionCheckList: NodeListOf<HTMLInputElement>;
	private selectAllCheckList: NodeListOf<HTMLInputElement>;
	private pageDefaultRadioList: NodeListOf<HTMLInputElement>;
	private btnCreates: NodeListOf<HTMLButtonElement>;
	private btnUpdates: NodeListOf<HTMLButtonElement>;
	private permissionErrorMessage: HTMLDivElement;

	/**
	 * Initialize
	 */
	public init(): void {
		this.handleCheckIsAction();

		this.hideMessage();
		this.setPermissionItemSelectEvent();
		this.setSelectAllChooseEvent();
		this.setCreateEvent();
		this.setUpdateEvent();
	}

	private handleCheckIsAction(): void {
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
	private setPermissionItemSelectEvent(): void {
		const onChangePermission = (event: Event): void => {
			// Get group element
			const targetElement = event.target as HTMLInputElement;

			// Get all permission input in group
			const permGroupItems = this.getPermissionGroupItems(targetElement)
			const isAllChecked = Array.from(permGroupItems).every(item => item.checked);

			// Set check status
			const selectAllCheck = this.getTargetSelectAllButton(targetElement) as HTMLInputElement;
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
	private setSelectAllChooseEvent(): void {
		const onChangeSelectAll = (event: Event): void => {
			const targetButton = event.target as HTMLInputElement;
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
		}

		// Set select all button change event
		this.selectAllCheckList.forEach((btnSelectAll) => {
			btnSelectAll.addEventListener('change', onChangeSelectAll);
		});
	}

	/**
	 * Set update button handler
	 */
	private setCreateEvent(): void {
		const onRequestSuccess = (response: ResponseBase<string>): void => {
			this.actionStatus = RoleSettingAction.Update;
			this.btnCreates.forEach(element => element.style.display = 'none');
			this.btnUpdates.forEach(element => element.style.display = 'block');
			this.btnSettingTab?.classList.remove('disabled');
			this.btnSettingTab?.click();

			console.log(response);
		}

		const onCreate = (event: Event): void => {
			if (this.actionStatus === RoleSettingAction.Update) {
				event.preventDefault();
				location.reload();
				return;
			}

			const targetElement = event.target as HTMLButtonElement;
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
	private setUpdateEvent(): void {
		const onRequestSuccess = (response: ResponseBase<string>): void => {
			console.log(response);
		}

		const onUpdate = (event: Event): void => {
			if (this.actionStatus === RoleSettingAction.Register) {
				event.preventDefault();
				location.reload();
				return;
			}

			const targetElement = event.target as HTMLButtonElement;
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
	private createRoleInfoRequest() : RoleInfoRequest {
		const result : RoleInfoRequest = {
			roleId: Number(this.roleIdInput?.value),
			name: this.roleNameInput?.value || '',
			priority: Number(this.rolePriorityInput?.value),
			status: Number(this.roleStatusInput?.value),
			description: this.roleDescriptionInput?.value || '',
		};
		return result;
	}
	type 

	/**
	 * Update role info
	 */
	private createUpdateRoleInfo(onSuccess: OnRequestSuccess<ResponseBase<string>>): void {
		const request: RoleInfoRequest = this.createRoleInfoRequest();
		RoleRequestService.updateRoleInfo(request, onSuccess);
	}

	/**
	 * Hide page message
	 */
	private hideMessage(): void {
		this.permissionErrorMessage.innerHTML = '';
		this.permissionErrorMessage.style.display = 'none';
	}

	/**
	 * Show message
	 * @param {string} message
	 */
	private showMessage(message = ''): void {
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
	private getTargetGroup(element: HTMLElement): HTMLElement {
		const result = element.closest(this.selector.permissionGroup) as HTMLElement;
		return result;
	}

	/**
	 * Get select all input element
	 * @param element Inner elements of the group (inner element of the accordion item)
	 * @returns {HTMLInputElement} Select all input element
	 */
	private getTargetSelectAllButton(element: HTMLElement): HTMLElement {
		const targetGroup = this.getTargetGroup(element);
		const result = targetGroup
			.querySelector(this.selector.innerSelectAllPerms) as HTMLInputElement
		return result;
	}

	/**
	 * Get all input permissions in a target group
	 * @param element Inner elements of the group (inner element of the accordion item)
	 * @returns {NodeListOf<HTMLInputElement>} All input permissions in the target group
	 */
	private getPermissionGroupItems(element: HTMLElement): NodeListOf<HTMLInputElement> {
		const targetGroup = this.getTargetGroup(element);
		const result = targetGroup
			.querySelectorAll(this.selector.innerPermissions) as NodeListOf<HTMLInputElement>;
		return result;
	}
}

// Execute role setting handler
StoreWindowLoadCallback.push(() => new RoleSettingHandler().init());
