// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public class ResponseResultViewModel<TResponse, TMessage>
	{
		public TResponse? Result { get; set; }

		public bool IsSuccess { get; set; }

		public TMessage? Message { get; set; }
	}
}
