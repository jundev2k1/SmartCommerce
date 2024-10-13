// Copyright (c) 2024 - Jun Dev. All rights reserved

import { ServiceBase } from '../base';
import { BodyRequest, OnRequestSuccess } from '../base-model';

/**
 * Role request service
 * @class
 */
export default class RoleService extends ServiceBase {
	constructor() {
		// Initialize page base
		super();
	}

	public static updateRoleInfo(request: RoleInfoRequest, onSuccess: OnRequestSuccess<ResponseBase<string>>) {
		const bodyRequest: BodyRequest<ResponseBase<string>> = {
			endpoint: '/role/setting/update-information',
			data: request,
			onSuccess: onSuccess,
		}
		this.callRequest(bodyRequest);
	}
}
