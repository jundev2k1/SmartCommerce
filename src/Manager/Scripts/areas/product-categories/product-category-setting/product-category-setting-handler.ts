// Copyright (c) 2025 - Jun Dev. All rights reserved

import { validateConfig } from './validate';

declare var datasource: CategoryItem[];

interface CategoryItem {
    parentID: string,
    categoryID: string,
    level: number,
    name: string,
    description: string,
    priority: number,
    items: CategoryItem[],
    hasChildItem: boolean,
    isDisplay: boolean,
};


/**
 * Product Category View Selector
 */
enum ViewSelector {
    // View control selector
    BTN_CLOSE = '#btnCloseInfo',
    INFORMATION_BOX = '.information-box',
    LIST = '.category-list',
    LIST_ITEM = '.category-item',
    LIST_ITEM_CONTENT = '.item-info',
    CLONE_ITEM = '.clone',
    BTN_COLLAPSE = '.btn-collapse',
    BTN_ADD_CATEGORY = '.btn-add-category',

    // Form information selector
    FORM = '#categoryForm',
    FORM_GROUP = '.form-group',
    FORM_GROUP_ERROR_MESSAGE = '.error-message',
    FORM_CONTROL = '#formControl',
    INPUT_PARENT_ID = '#parentID',
    INPUT_CATE_ID = '#categoryID',
    INPUT_CATE_NAME = '#cateName',
    INPUT_CATE_DESC = '#cateDesc',
};

/**
 * Input type
 */
enum InputType {
    TEXT_BOX,
    CHECK_BOX,
};

/**
 * Action
 */
enum Action {
    READ,
    INSERT,
    MODIFY,
};

class categoryHandlerBase {
    // Local variable: handle state
    public _isProcessing: boolean = false;

    get divInformationBox(): HTMLDivElement {
        return document.querySelector(ViewSelector.INFORMATION_BOX)!;
    }

    /**
     * Get item data from datasource
     * @param searchPredicate A predicate to map with validing value
     */
    public getItemData(searchPredicate: (item: CategoryItem) => boolean): CategoryItem | null {
        let targetItem: CategoryItem | null = null;

        // Find from child items
        const findItem = (items: CategoryItem[]) => {
            items.forEach(childItem => {
                // Break if target item is definded
                if (targetItem) return;

                if (searchPredicate(childItem)) {
                    targetItem = childItem;
                    return;
                };

                // Recursive search
                findItem(childItem.items);
            });
        }

        findItem(datasource);
        return targetItem;
    }

    /**
     * Select many target value
     * @param item Category item
     * @param selectFunc Select target value function
     * @returns A target value list
     */
    public getChildDatas<T>(item: CategoryItem, selectFunc: (target: CategoryItem) => T): T[] {
        const result = [selectFunc(item)];

        this.findChildItem(item, (target) => {
            result.push(selectFunc(target));
        });

        return result;
    }

    /**
     * Find child item
     * @param item Category item
     * @param action Execute foreach accessing item
     */
    public findChildItem(item: CategoryItem, action: (target: CategoryItem) => void): void {
        const selectItem = (items: CategoryItem[]) => {
            items.forEach(childItem => {
                action?.(childItem);

                selectItem(childItem.items);
            });
        };
        selectItem(item.items);
    }

    /**
     * Add a new item to datasource
     * @param newItems A new item to add to datasource
     */
    public addNewData(newItems: CategoryItem[]) {
        // Handle remove for the root category
        if (newItems[0].parentID === 'root') {
            newItems.forEach(newItem => datasource.push(newItem));
            return;
        };

        datasource.forEach(item => {
            if (item.categoryID === newItems[0].parentID) {
                newItems.forEach(newItem => item.items.push(newItem));
                return;
            }

            this.findChildItem(item, (target) => {
                if (target.categoryID !== newItems[0].parentID) return;

                newItems.forEach(newItem => target.items.push(newItem));
            });
        });
    }

    /**
     * Remove target item from datasource
     * @param targetItem The target item will be removed from datasource
     */
    public removeData(targetItem: CategoryItem) {
        // Handle remove for the root category
        if (targetItem.parentID === 'root') {
            datasource = datasource.filter(item => item.categoryID != targetItem.categoryID)
            return;
        }

        // Handle remove for child category
        datasource.forEach(item => {
            if (item.categoryID === targetItem.parentID) {
                item.items = item.items.filter(childItem => childItem.categoryID !== targetItem.categoryID);
                return;
            }

            this.findChildItem(item, (target) => {
                if (target.categoryID !== targetItem.parentID) return;

                target.items = target.items.filter(childItem => childItem.categoryID !== targetItem.categoryID);
            });
        });
    }

    /**
     * Modify target item from datasource
     * @param targetItem The target item will be modified from datasource
     * @param modifyAction Update data after item found
     */
    public modifyData(targetItem: CategoryItem, modifyAction: (target: CategoryItem) => void) {
        datasource.forEach(item => {
            // Handle remove for root category
            if (item.categoryID === targetItem.categoryID) {
                modifyAction(item);
                return;
            }

            // Handle modify for child category
            this.findChildItem(item, (target) => {
                if (target.categoryID !== targetItem.categoryID) return;

                modifyAction(target);
            });
        });
    }

    /**
     * Clear error message
     */
    public clearErrorMessage() {
        document.querySelectorAll(ViewSelector.FORM_GROUP_ERROR_MESSAGE)
            .forEach(element => element.innerHTML = '');
    }
}

/**
 * Category information handler
 * Handles form-related operations (CRUD form,...)
 */
class categoryInformationHandler extends categoryHandlerBase {
    private _targetData: CategoryItem;
    private _action: Action;
    private _onReloadList?: () => void;

    constructor(targetData: CategoryItem, action: Action, onReload?: () => void) {
        super();
        this._targetData = targetData;
        this._action = action;
        this._onReloadList = onReload;
        this.onLoad();
    }

    /** Text box: parent category ID */
    get tbParentId(): HTMLInputElement {
        return document.querySelector<HTMLInputElement>(ViewSelector.INPUT_PARENT_ID)!;
    }
    /** Text box: Category ID */
    get tbCategoryId(): HTMLInputElement {
        return document.querySelector<HTMLInputElement>(ViewSelector.INPUT_CATE_ID)!;
    }
    /** Text box: Name */
    get tbName(): HTMLInputElement {
        return document.querySelector<HTMLInputElement>(ViewSelector.INPUT_CATE_NAME)!;
    }
    /** Text box: Description */
    get tbDescription(): HTMLInputElement {
        return document.querySelector<HTMLInputElement>(ViewSelector.INPUT_CATE_DESC)!;
    }
    /** Wrapper: form control area */
    get divFormControl(): HTMLDivElement {
        return document.querySelector<HTMLDivElement>(ViewSelector.FORM_CONTROL)!;
    }

    /**
     * On load form
     */
    public onLoad() {
        // Set form data
        this.tbParentId.disabled = true;
        this.tbParentId.value = this._targetData.parentID;
        this.tbCategoryId.value = this._targetData.categoryID;
        this.tbCategoryId.disabled = this._action === Action.MODIFY;
        this.tbName.value = this._targetData.name;
        this.tbDescription.value = this._targetData.description;

        this.divInformationBox.style.display = '';
        this.setFormControl();

        // Set validate form
        $(ViewSelector.FORM).validate(validateConfig);
    }

    /**
     * Submit form event
     */
    public onSubmit(event: Event, action: Action) {
        event.preventDefault();
        if (this._isProcessing) return;

        // Validate form
        this.clearErrorMessage();
        const isValidForm = $(ViewSelector.FORM).valid();
        if (!isValidForm) return;

        const formData = this.getFormValue();
        switch (action) {
            case Action.INSERT:
                this.addNewData([formData]);
                break;

            case Action.MODIFY:
                this.modifyData(this._targetData, item => {
                    item.categoryID = formData.categoryID;
                    item.name = formData.name;
                    item.description = formData.description;
                });
                break;
        }
        this.clearErrorMessage();
    }

    /**
     * Delete category event
     */
    public onDelete() {
        if (!this._isProcessing) return;

        const relatedCategories = this.getChildDatas(this._targetData, item => item.categoryID);
        const alertMessage = `Are you sure if you delete the following items: ${relatedCategories.join(', ')}`;
        if (!confirm(alertMessage)) return;

        this.removeData(this._targetData);
        this._onReloadList?.();
    }

    /**
     * Get form value
     * @returns The data from input form
     */
    private getFormValue(): CategoryItem {
        const formData = this._targetData;
        formData.categoryID = this.tbCategoryId.value.trim();
        formData.name = this.tbName.value.trim();
        formData.description = this.tbDescription.value.trim();
        return formData;
    }

    /**
     * Set form control
     */
    private setFormControl() {
        switch (this._action) {
            case Action.INSERT:
                this.divFormControl.innerHTML = `<input id="btnSubmit" type="submit" class="btn btn-primary" value="Register" />`;
                break;

            case Action.MODIFY:
                this.divFormControl.innerHTML = `
          <input id="btnSubmit" type="submit" class="btn btn-primary" value="Modify" />
          <button id="btnDelete" class="btn btn-danger">Delete</button>`;
                break;
        }

        document.querySelector(ViewSelector.FORM)?.addEventListener('submit', (event) => this.onSubmit(event, this._action));
        document.querySelector('#btnDelete')?.addEventListener('click', () => this.onDelete());
    }
};

/**
 * Product category handler
 * Handles common
 */
class productCategoryHandler extends categoryHandlerBase {
    // Getter
    get btnCloseInfo(): HTMLElement {
        return document.querySelector(ViewSelector.BTN_CLOSE)!;
    }
    get divCategoryList(): HTMLUListElement {
        return document.querySelector<HTMLUListElement>('.category-list.root-category')!;
    }
    get cloneTemplateItem(): HTMLLIElement {
        const node = document.createElement('li');
        node.className = 'category-item';
        node.innerHTML = `
      <div class="item-info clone">
        +
        <p>Clone<i>👁‍🗨</i></p>
      </div>`;
        return node;
    }


    // =======================================
    // Event group function
    // =======================================

    /**
     * Read category item information
     * @param {Event} event On click event
     */
    private onReadInfo(event: Event): void {
        if (this._isProcessing) return;

        const targetElement = (event.target as HTMLElement)
            .closest(ViewSelector.LIST_ITEM_CONTENT) as HTMLDivElement;
        if (!targetElement) return;

        // Clear all clone item
        this.clearClone();
        $(ViewSelector.LIST_ITEM_CONTENT).removeClass('choose');
        targetElement.classList.add('choose');

        const targetCateID = targetElement.dataset['itemId'] || '';
        const targetData = this.getItemData(item => item.categoryID === targetCateID);
        if (!targetData) return location.reload();

        new categoryInformationHandler(targetData, Action.MODIFY, () => this.init());
    }

    /**
     * Close category item information
     */
    private onCloseInfo(): void {
        if (this._isProcessing) return;

        // Hide information box
        this.divInformationBox.style.display = 'none';

        // Clear form
        this.clearInput(ViewSelector.INPUT_PARENT_ID);
        this.clearInput(ViewSelector.INPUT_CATE_ID);
        this.clearInput(ViewSelector.INPUT_CATE_NAME);
        this.clearInput(ViewSelector.INPUT_CATE_DESC);

        // Clear all clone item
        this.clearClone();

        // Remove validate config
        $(ViewSelector.INFORMATION_BOX).validate().destroy();
        $(ViewSelector.LIST_ITEM_CONTENT).removeClass('choose');
        this.clearErrorMessage();
    }

    /**
     * On collapse category item
     * @param {HTMLInputElement} targetButton Collapse button
     */
    private onCollapse(targetButton: HTMLInputElement): void {
        if (this._isProcessing) return;

        const targetItem = targetButton.closest(ViewSelector.LIST_ITEM) as HTMLLIElement;
        if (!targetItem) return;

        const itemContent = targetItem
            .querySelector<HTMLDivElement>(ViewSelector.LIST_ITEM_CONTENT);
        const categoryId = itemContent?.dataset['itemId'] || '';
        const targetData = this.getItemData(item => item.categoryID === categoryId);
        if (!targetData) return;

        // Set "add new" button status
        const isCollapsed = targetItem.classList.contains('collapsed');
        const btnAdd = targetItem.querySelector<HTMLButtonElement>(`${ViewSelector.LIST_ITEM_CONTENT} ${ViewSelector.BTN_ADD_CATEGORY}`);
        if (btnAdd) btnAdd.disabled = !isCollapsed;

        // Hide child items
        if (!isCollapsed) {
            targetItem.classList.add('collapsed');
            targetData.isDisplay = false;
            targetButton.innerHTML = '<i class="fa-solid fa-caret-up"></i>';
            return;
        }

        // If needn't fetch data, just set state and exit the function
        const canFetch = targetButton.dataset['canFetch'] === 'true';
        if (!canFetch) {
            targetItem.classList.remove('collapsed');
            targetData.isDisplay = true;
            targetButton.innerHTML = '<i class="fa-solid fa-caret-down"></i>';
            return;
        }

        // Handle if child items fetchable
        targetButton.innerHTML = '<i class="fa-solid fa-spinner"></i>';
        targetButton.classList.add('is-fetching');
        this.fetchChildItems(categoryId, (res: CategoryItem[]) => {
            targetButton.innerHTML = '<i class="fa-solid fa-caret-down"></i>';
            targetData.isDisplay = true;
            targetData.f
            targetItem.classList.remove('collapsed');
            targetButton.classList.remove('is-fetching');
            targetButton.removeAttribute('data-can-fetch');

            this.addNewData(res);
            this.init();
        });
    }

    /**
     * On add category
     * @param {HTMLInputElement} targetButton Add category button
     */
    private onAddCategory(targetButton: HTMLInputElement) {
        if (this._isProcessing) return;

        const targetCategoryGroup = targetButton.closest<HTMLLIElement>(ViewSelector.LIST_ITEM);
        if (!targetCategoryGroup) return;

        // Clear all clone button
        this.clearClone();

        // Open information box and set new item data
        const targetCategoryId = targetButton
            .closest<HTMLDivElement>(ViewSelector.LIST_ITEM_CONTENT)
            ?.dataset['itemId'] || '';
        if (!targetCategoryId) return;

        const targetData = this.getItemData(item => item.categoryID === targetCategoryId);
        if (!targetData || (targetData.hasChildItem && !targetData.isDisplay)) return;

        // Load target data to information box
        const priorityList = targetData.items.map(item => item.priority);
        const nextPriority = priorityList.length ? Math.max(...priorityList) + 1 : 1;
        const newData: CategoryItem = {
            parentID: targetData.categoryID,
            categoryID: '',
            name: '',
            description: '',
            priority: nextPriority,
            items: [],
            hasChildItem: false,
            isDisplay: false,
            level: targetData.level + 1,
        };
        new categoryInformationHandler(newData, Action.INSERT, () => this.init());

        // Set display clone item
        const childList = targetCategoryGroup.querySelector<HTMLUListElement>(ViewSelector.LIST);
        if (!childList) return;

        childList.append(this.cloneTemplateItem);
    }

    /**
     * Clear input
     * @param {string} selector Element selector
     * @param {InputType} type Input type
     */
    private clearInput(selector = '', type = InputType.TEXT_BOX): void {
        const targetInput = document.querySelector(selector) as HTMLInputElement;
        if (!targetInput) return;

        switch (type) {
            case InputType.TEXT_BOX:
                targetInput.value = '';
                break;

            case InputType.CHECK_BOX:
                targetInput.checked = false;
                break;
        }
    }

    /**
     * Clear all clone nodes
     */
    private clearClone(): void {
        const items = document.querySelectorAll(ViewSelector.CLONE_ITEM);
        items.forEach(item => {
            const targetElement = item.closest(ViewSelector.LIST_ITEM);
            if (!targetElement) return;

            targetElement.remove();
        });
    }

    /**
     * Fetch child items
     * @param categoryId Target category ID
     * @param callback The callback will execute after fetch already done
     */
    private fetchChildItems(categoryId: string, callback: (res: CategoryItem[]) => void,) {
        this._isProcessing = true;
        $.ajax({
            url: '/product-category/get-child-category',
            method: "GET",
            dataType: 'json',
            data: { categoryId: categoryId },
            success: (response) => {
                callback?.(JSON.parse(response) as CategoryItem[]);
                this._isProcessing = false;
            },
        });
    }


    // =======================================
    // Render group function
    // =======================================

    /**
     * Sort data (sort by Priority, then by Category ID)
     */
    public sort() {
        const sortChildItems = (items: CategoryItem[]) => {
            // Sort by Priority, then by Category ID
            items = items.sort((a, b) => a.priority != a.priority
                ? a.priority - b.priority
                : a.categoryID.localeCompare(b.categoryID));

            items.forEach(item => {
                sortChildItems(item.items);
            });
        };

        sortChildItems(datasource);
    }

    /**
     * Render to view from datasource
     */
    public renderView() {
        const rootNode = document.createElement('ul');

        const createTemplate = (item: CategoryItem) => {
            const { isDisplay, categoryID, name, hasChildItem, items } = item;
            const canFetch = hasChildItem && items.length === 0;
            const isCollapse = hasChildItem && !isDisplay;

            const template = ''
                + `<li class="category-item ${isCollapse ? 'collapsed' : ''}">`
                + `  <div class="item-info" data-item-id="${categoryID}">`
                + `    <p>${name}<i>👁‍🗨</i></p>`
                + `    <div class="item-control">`
                + `      <button class="btn btn-success btn-add-category" ${isCollapse ? 'disabled' : ''}>+</button>`
                + `      <button class="btn btn-info btn-collapse" ${canFetch ? 'data-can-fetch="true"' : ''} ${!hasChildItem && !canFetch ? 'disabled' : ''}>`
                + `         ${!isDisplay ? '<i class="fa-solid fa-caret-up"></i>' : '<i class="fa-solid fa-caret-down"></i>'}`
                + `       </button>`
                + `    </div>`
                + `  </div>`
                + `  <ul class="category-list"></ul>`
                + `</li>`;
            return template;
        };

        const createCategoryItem = (item: CategoryItem): void => {
            const parentNode = item.parentID !== 'root'
                ? rootNode.querySelector<HTMLLIElement>(`[data-item-id="${item.parentID}"]`)
                    ?.parentElement
                    ?.querySelector<HTMLUListElement>(ViewSelector.LIST)
                : rootNode;
            if (!parentNode) return;

            const template = createTemplate(item);
            parentNode.innerHTML += template;
        };

        const setChildItem = (items: CategoryItem[]) => {
            items.forEach(childItem => {
                createCategoryItem(childItem);

                setChildItem(childItem.items);
            });
        };

        setChildItem(datasource);
        this.divCategoryList.innerHTML = rootNode.innerHTML;
    }


    // =======================================
    // Initialize class
    // =======================================

    /**
     * Set initialize event
     */
    private setInitEvent() {
        // Set close event for information box
        this.btnCloseInfo?.addEventListener('click', () => this.onCloseInfo());

        // Set show information event
        document.querySelectorAll(`${ViewSelector.LIST_ITEM_CONTENT} p`).forEach(element => {
            element.addEventListener('click', (event) => this.onReadInfo(event));
        });

        // Set collapse event
        document.querySelectorAll(ViewSelector.BTN_COLLAPSE).forEach(element => {
            element.addEventListener('click', () => this.onCollapse(element as HTMLInputElement));
        });

        // Set add category event
        document.querySelectorAll(ViewSelector.BTN_ADD_CATEGORY).forEach(element => {
            element.addEventListener('click', () => this.onAddCategory(element as HTMLInputElement));
        });
    }

    /**
     * Initialize class
     */
    public init() {
        this.sort();
        this.renderView();
        this.setInitEvent();
    }
};

new productCategoryHandler().init();