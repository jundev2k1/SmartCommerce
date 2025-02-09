// Copyright (c) 2024 - Jun Dev. All rights reserved
import { ServiceBase } from '../base.js';
/**
 * Role request service
 * @class
 */
export default class RoleService extends ServiceBase {
    constructor() {
        // Initialize page base
        super();
    }
    static updateRoleInfo(request, onSuccess) {
        const bodyRequest = {
            endpoint: '/role/setting/update-information',
            data: request,
            onSuccess: onSuccess,
        };
        this.callRequest(bodyRequest);
    }
}
