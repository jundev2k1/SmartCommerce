// Copyright (c) 2024 - Jun Dev. All rights reserved

enum RequestType {
	Json = 'json',
	FormUrlEncoded = 'form-url-encoded',
	FormData = 'form-data',
	TextPlain = 'text-plain'
};

interface BodyRequest<T> {
	endpoint: string,
	data: any,
	type: RequestType,
	method: string,
	onSuccess: OnRequestSuccess<T>,
	onError: OnRequestError
}

type OnRequestSuccess<T> = (response: T) => void;

type OnRequestError = (jqXHR: any, textStatus: string, errorThrown: string | Error) => void;
