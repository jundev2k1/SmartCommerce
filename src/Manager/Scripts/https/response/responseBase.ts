// Copyright (c) 2024 - Jun Dev. All rights reserved

interface ResponseBase<T> {
	result: T,
	status: boolean,
	message: string | Record<string, any>,
}
