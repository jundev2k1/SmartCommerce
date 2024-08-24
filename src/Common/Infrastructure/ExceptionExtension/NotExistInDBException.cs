// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.ExceptionExtension
{
	public sealed class NotExistInDBException : Exception
	{
		private readonly string? _errorMessage;

		const string CONST_DEFAULT_ERROR_MESSAGE = "This item [{0}] does not exist";

		public NotExistInDBException()
		{
			_errorMessage = GetErrorMessage();
		}

		public NotExistInDBException(string message) : base(message)
		{
			_errorMessage = GetErrorMessage(message);
		}

		public NotExistInDBException(string message, Exception inner)
			: base(message, inner)
		{
			_errorMessage = GetErrorMessage(message);
		}

		public string GetErrorMessage(string messageInput = CONST_DEFAULT_ERROR_MESSAGE)
		{
			return string.Format(messageInput, ItemInfo);
		}

		public override string Message => _errorMessage ?? base.Message;
		public string ItemInfo { get; set; } = string.Empty;
	}
}
