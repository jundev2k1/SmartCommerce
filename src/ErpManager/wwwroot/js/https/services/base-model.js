// Copyright (c) 2024 - Jun Dev. All rights reserved
export var RequestType;
(function (RequestType) {
    RequestType["Json"] = "json";
    RequestType["FormUrlEncoded"] = "form-url-encoded";
    RequestType["FormData"] = "form-data";
    RequestType["TextPlain"] = "text-plain";
})(RequestType || (RequestType = {}));
;
export var RequestMethod;
(function (RequestMethod) {
    RequestMethod["Get"] = "GET";
    RequestMethod["Post"] = "POST";
})(RequestMethod || (RequestMethod = {}));
