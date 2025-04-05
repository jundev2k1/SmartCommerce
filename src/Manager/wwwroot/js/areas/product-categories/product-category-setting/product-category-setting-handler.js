// Copyright (c) 2025 - Jun Dev. All rights reserved
import { validateConfig } from './validate.js';
;
/**
 * Product Category View Selector
 */
var ViewSelector;
(function (ViewSelector) {
    // View control selector
    ViewSelector["BTN_CLOSE"] = "#btnCloseInfo";
    ViewSelector["INFORMATION_BOX"] = ".information-box";
    ViewSelector["LIST"] = ".category-list";
    ViewSelector["LIST_ITEM"] = ".category-item";
    ViewSelector["LIST_ITEM_CONTENT"] = ".item-info";
    ViewSelector["CLONE_ITEM"] = ".clone";
    ViewSelector["BTN_COLLAPSE"] = ".btn-collapse";
    ViewSelector["BTN_ADD_CATEGORY"] = ".btn-add-category";
    // Form information selector
    ViewSelector["FORM"] = "#categoryForm";
    ViewSelector["FORM_GROUP"] = ".form-group";
    ViewSelector["FORM_GROUP_ERROR_MESSAGE"] = ".error-message";
    ViewSelector["FORM_CONTROL"] = "#formControl";
    ViewSelector["INPUT_PARENT_ID"] = "#parentID";
    ViewSelector["INPUT_CATE_ID"] = "#categoryID";
    ViewSelector["INPUT_CATE_NAME"] = "#cateName";
    ViewSelector["INPUT_CATE_DESC"] = "#cateDesc";
})(ViewSelector || (ViewSelector = {}));
;
/**
 * Input type
 */
var InputType;
(function (InputType) {
    InputType[InputType["TEXT_BOX"] = 0] = "TEXT_BOX";
    InputType[InputType["CHECK_BOX"] = 1] = "CHECK_BOX";
})(InputType || (InputType = {}));
;
/**
 * Action
 */
var Action;
(function (Action) {
    Action[Action["READ"] = 0] = "READ";
    Action[Action["INSERT"] = 1] = "INSERT";
    Action[Action["MODIFY"] = 2] = "MODIFY";
})(Action || (Action = {}));
;
class categoryHandlerBase {
    // Local variable: handle state
    _isProcessing = false;
    get divInformationBox() {
        return document.querySelector(ViewSelector.INFORMATION_BOX);
    }
    /**
     * Get item data from datasource
     * @param searchPredicate A predicate to map with validing value
     */
    getItemData(searchPredicate) {
        let targetItem = null;
        // Find from child items
        const findItem = (items) => {
            items.forEach(childItem => {
                // Break if target item is definded
                if (targetItem)
                    return;
                if (searchPredicate(childItem)) {
                    targetItem = childItem;
                    return;
                }
                ;
                // Recursive search
                findItem(childItem.items);
            });
        };
        findItem(datasource);
        return targetItem;
    }
    /**
     * Select many target value
     * @param item Category item
     * @param selectFunc Select target value function
     * @returns A target value list
     */
    getChildDatas(item, selectFunc) {
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
    findChildItem(item, action) {
        const selectItem = (items) => {
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
    addNewData(newItems) {
        // Handle remove for the root category
        if (newItems[0].parentID === 'root') {
            newItems.forEach(newItem => datasource.push(newItem));
            return;
        }
        ;
        datasource.forEach(item => {
            if (item.categoryID === newItems[0].parentID) {
                newItems.forEach(newItem => item.items.push(newItem));
                return;
            }
            this.findChildItem(item, (target) => {
                if (target.categoryID !== newItems[0].parentID)
                    return;
                newItems.forEach(newItem => target.items.push(newItem));
            });
        });
    }
    /**
     * Remove target item from datasource
     * @param targetItem The target item will be removed from datasource
     */
    removeData(targetItem) {
        // Handle remove for the root category
        if (targetItem.parentID === 'root') {
            datasource = datasource.filter(item => item.categoryID != targetItem.categoryID);
            return;
        }
        // Handle remove for child category
        datasource.forEach(item => {
            if (item.categoryID === targetItem.parentID) {
                item.items = item.items.filter(childItem => childItem.categoryID !== targetItem.categoryID);
                return;
            }
            this.findChildItem(item, (target) => {
                if (target.categoryID !== targetItem.parentID)
                    return;
                target.items = target.items.filter(childItem => childItem.categoryID !== targetItem.categoryID);
            });
        });
    }
    /**
     * Modify target item from datasource
     * @param targetItem The target item will be modified from datasource
     * @param modifyAction Update data after item found
     */
    modifyData(targetItem, modifyAction) {
        datasource.forEach(item => {
            // Handle remove for root category
            if (item.categoryID === targetItem.categoryID) {
                modifyAction(item);
                return;
            }
            // Handle modify for child category
            this.findChildItem(item, (target) => {
                if (target.categoryID !== targetItem.categoryID)
                    return;
                modifyAction(target);
            });
        });
    }
    /**
     * Clear error message
     */
    clearErrorMessage() {
        document.querySelectorAll(ViewSelector.FORM_GROUP_ERROR_MESSAGE)
            .forEach(element => element.innerHTML = '');
    }
}
/**
 * Category information handler
 * Handles form-related operations (CRUD form,...)
 */
class categoryInformationHandler extends categoryHandlerBase {
    _targetData;
    _action;
    _onReloadList;
    constructor(targetData, action, onReload) {
        super();
        this._targetData = targetData;
        this._action = action;
        this._onReloadList = onReload;
        this.onLoad();
    }
    /** Text box: parent category ID */
    get tbParentId() {
        return document.querySelector(ViewSelector.INPUT_PARENT_ID);
    }
    /** Text box: Category ID */
    get tbCategoryId() {
        return document.querySelector(ViewSelector.INPUT_CATE_ID);
    }
    /** Text box: Name */
    get tbName() {
        return document.querySelector(ViewSelector.INPUT_CATE_NAME);
    }
    /** Text box: Description */
    get tbDescription() {
        return document.querySelector(ViewSelector.INPUT_CATE_DESC);
    }
    /** Wrapper: form control area */
    get divFormControl() {
        return document.querySelector(ViewSelector.FORM_CONTROL);
    }
    /**
     * On load form
     */
    onLoad() {
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
    onSubmit(event, action) {
        event.preventDefault();
        if (this._isProcessing)
            return;
        // Validate form
        this.clearErrorMessage();
        const isValidForm = $(ViewSelector.FORM).valid();
        if (!isValidForm)
            return;
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
    onDelete() {
        if (!this._isProcessing)
            return;
        const relatedCategories = this.getChildDatas(this._targetData, item => item.categoryID);
        const alertMessage = `Are you sure if you delete the following items: ${relatedCategories.join(', ')}`;
        if (!confirm(alertMessage))
            return;
        this.removeData(this._targetData);
        this._onReloadList?.();
    }
    /**
     * Get form value
     * @returns The data from input form
     */
    getFormValue() {
        const formData = this._targetData;
        formData.categoryID = this.tbCategoryId.value.trim();
        formData.name = this.tbName.value.trim();
        formData.description = this.tbDescription.value.trim();
        return formData;
    }
    /**
     * Set form control
     */
    setFormControl() {
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
}
;
/**
 * Product category handler
 * Handles common
 */
class productCategoryHandler extends categoryHandlerBase {
    // Getter
    get btnCloseInfo() {
        return document.querySelector(ViewSelector.BTN_CLOSE);
    }
    get divCategoryList() {
        return document.querySelector('.category-list.root-category');
    }
    get cloneTemplateItem() {
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
    onReadInfo(event) {
        if (this._isProcessing)
            return;
        const targetElement = event.target
            .closest(ViewSelector.LIST_ITEM_CONTENT);
        if (!targetElement)
            return;
        // Clear all clone item
        this.clearClone();
        $(ViewSelector.LIST_ITEM_CONTENT).removeClass('choose');
        targetElement.classList.add('choose');
        const targetCateID = targetElement.dataset['itemId'] || '';
        const targetData = this.getItemData(item => item.categoryID === targetCateID);
        if (!targetData)
            return location.reload();
        new categoryInformationHandler(targetData, Action.MODIFY, () => this.init());
    }
    /**
     * Close category item information
     */
    onCloseInfo() {
        if (this._isProcessing)
            return;
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
    onCollapse(targetButton) {
        if (this._isProcessing)
            return;
        const targetItem = targetButton.closest(ViewSelector.LIST_ITEM);
        if (!targetItem)
            return;
        const itemContent = targetItem
            .querySelector(ViewSelector.LIST_ITEM_CONTENT);
        const categoryId = itemContent?.dataset['itemId'] || '';
        const targetData = this.getItemData(item => item.categoryID === categoryId);
        if (!targetData)
            return;
        // Set "add new" button status
        const isCollapsed = targetItem.classList.contains('collapsed');
        const btnAdd = targetItem.querySelector(`${ViewSelector.LIST_ITEM_CONTENT} ${ViewSelector.BTN_ADD_CATEGORY}`);
        if (btnAdd)
            btnAdd.disabled = !isCollapsed;
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
        this.fetchChildItems(categoryId, (res) => {
            targetButton.innerHTML = '<i class="fa-solid fa-caret-down"></i>';
            targetData.isDisplay = true;
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
    onAddCategory(targetButton) {
        if (this._isProcessing)
            return;
        const targetCategoryGroup = targetButton.closest(ViewSelector.LIST_ITEM);
        if (!targetCategoryGroup)
            return;
        // Clear all clone button
        this.clearClone();
        // Open information box and set new item data
        const targetCategoryId = targetButton
            .closest(ViewSelector.LIST_ITEM_CONTENT)
            ?.dataset['itemId'] || '';
        if (!targetCategoryId)
            return;
        const targetData = this.getItemData(item => item.categoryID === targetCategoryId);
        if (!targetData || (targetData.hasChildItem && !targetData.isDisplay))
            return;
        // Load target data to information box
        const priorityList = targetData.items.map(item => item.priority);
        const nextPriority = priorityList.length ? Math.max(...priorityList) + 1 : 1;
        const newData = {
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
        const childList = targetCategoryGroup.querySelector(ViewSelector.LIST);
        if (!childList)
            return;
        childList.append(this.cloneTemplateItem);
    }
    /**
     * Clear input
     * @param {string} selector Element selector
     * @param {InputType} type Input type
     */
    clearInput(selector = '', type = InputType.TEXT_BOX) {
        const targetInput = document.querySelector(selector);
        if (!targetInput)
            return;
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
    clearClone() {
        const items = document.querySelectorAll(ViewSelector.CLONE_ITEM);
        items.forEach(item => {
            const targetElement = item.closest(ViewSelector.LIST_ITEM);
            if (!targetElement)
                return;
            targetElement.remove();
        });
    }
    /**
     * Fetch child items
     * @param targetId Target category ID
     * @param callback The callback will execute after fetch already done
     */
    fetchChildItems(targetId, callback) {
        this._isProcessing = true;
        $.ajax({
            url: '/product-category/get-child-category',
            method: "GET",
            dataType: 'json',
            data: { categoryId: targetId },
            success: (response) => {
                callback?.(JSON.parse(response));
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
    sort() {
        const sortChildItems = (items) => {
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
    renderView() {
        const rootNode = document.createElement('ul');
        const createTemplate = (item) => {
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
        const createCategoryItem = (item) => {
            const parentNode = item.parentID !== 'root'
                ? rootNode.querySelector(`[data-item-id="${item.parentID}"]`)
                    ?.parentElement
                    ?.querySelector(ViewSelector.LIST)
                : rootNode;
            if (!parentNode)
                return;
            const template = createTemplate(item);
            parentNode.innerHTML += template;
        };
        const setChildItem = (items) => {
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
    setInitEvent() {
        // Set close event for information box
        this.btnCloseInfo?.addEventListener('click', () => this.onCloseInfo());
        // Set show information event
        document.querySelectorAll(`${ViewSelector.LIST_ITEM_CONTENT} p`).forEach(element => {
            element.addEventListener('click', (event) => this.onReadInfo(event));
        });
        // Set collapse event
        document.querySelectorAll(ViewSelector.BTN_COLLAPSE).forEach(element => {
            element.addEventListener('click', () => this.onCollapse(element));
        });
        // Set add category event
        document.querySelectorAll(ViewSelector.BTN_ADD_CATEGORY).forEach(element => {
            element.addEventListener('click', () => this.onAddCategory(element));
        });
    }
    /**
     * Initialize class
     */
    init() {
        this.sort();
        this.renderView();
        this.setInitEvent();
    }
}
;
new productCategoryHandler().init();
