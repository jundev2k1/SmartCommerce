// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.ExceptionExtension
{
	public sealed class NotExistInDBException : Exception
	{
		const string CONST_DEFAULT_ERROR_MESSAGE = "This item does not exist";

		public NotExistInDBException() : base(CONST_DEFAULT_ERROR_MESSAGE)
		{
		}

		public NotExistInDBException(string message) : base(message)
		{
		}

		public NotExistInDBException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
