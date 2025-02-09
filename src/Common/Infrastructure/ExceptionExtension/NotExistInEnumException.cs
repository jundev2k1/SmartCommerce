// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.ExceptionExtension
{
	public sealed class NotExistInEnumException : Exception
	{
		const string CONST_DEFAULT_ERROR_MESSAGE = "This value is not exist in enum";

		public NotExistInEnumException() : base(CONST_DEFAULT_ERROR_MESSAGE)
		{
		}

		public NotExistInEnumException(string message) : base(message)
		{
		}

		public NotExistInEnumException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
