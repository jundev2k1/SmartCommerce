// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.ExceptionExtension
{
	public sealed class ExistInDBException : Exception
	{
		const string CONST_DEFAULT_ERROR_MESSAGE = "This item already exists";

		public ExistInDBException() : base(CONST_DEFAULT_ERROR_MESSAGE)
		{
		}

		public ExistInDBException(string message) : base(message)
		{
		}

		public ExistInDBException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
