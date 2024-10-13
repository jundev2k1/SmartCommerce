// Copyright (c) 2024 - Jun Dev. All rights reserved

export enum RequestType {
	Json = 'json',
	FormUrlEncoded = 'form-url-encoded',
	FormData = 'form-data',
	TextPlain = 'text-plain'
};

export enum RequestMethod {
	Get = 'GET',
	Post = 'POST',
}

export interface BodyRequest<T> {
	endpoint: string,
	data: any,
	type?: RequestType,
	method?: RequestMethod,
	onSuccess: OnRequestSuccess<T>,
	onError?: OnRequestError,
}

export type OnRequestSuccess<T> = (response: T) => void;

export type OnRequestError = (jqXHR: any, textStatus: string, errorThrown: string | Error) => void;
