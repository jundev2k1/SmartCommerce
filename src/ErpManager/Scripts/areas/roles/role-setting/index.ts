// Copyright (c) 2024 - Jun Dev. All rights reserved

// Declare global variable
declare const StoreWindowLoadCallback: any[];

/**
 * Role setting page handler
 * @class
 */
class RoleSettingHandler extends RoleBase {
	private selector = Object.freeze({
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

	/**
	 * Class Constructor
	*/
	constructor() {
		// Initialize Role Base
		super();

		// Initialize
		this.permissionCheckList = document.querySelectorAll(this.selector.permissions);
		this.selectAllCheckList = document.querySelectorAll(this.selector.selectAllPerms);
		this.pageDefaultRadioList = document.querySelectorAll(this.selector.pageDefaults);
		this.btnUpdates = document.querySelectorAll(this.selector.buttonUpdates);
	}

	// Declare class local properties
	private permissionCheckList: NodeListOf<HTMLInputElement>;
	private selectAllCheckList: NodeListOf<HTMLInputElement>;
	private pageDefaultRadioList: NodeListOf<HTMLInputElement>;
	private btnUpdates: NodeListOf<HTMLButtonElement>;

	/**
	 * Initialize class
	 */
	public init(): void {
		this.setPermissionItemSelectEvent();
		this.setSelectAllChooseEvent();
		this.setUpdateEvent();
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
			const isAllChecked = Array.from(permGroupItems).some(item => !item.checked) == false;

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
	private setUpdateEvent(): void {
		const onUpdate = (event: Event): void => {
			const targetElement = event.target as HTMLButtonElement;
		};

		// Add click event
		this.btnUpdates.forEach((button) => {
			button.addEventListener('click', onUpdate);
		});
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
