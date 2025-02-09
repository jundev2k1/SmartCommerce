// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Fields;
using SmartCommerce.Manager.Globals;
using SmartCommerce.Manager.Messages;
using SmartCommerce.Manager.Validators;
using SmartCommerce.Manager.ValueTexts;

namespace SmartCommerce.Manager.Common
{
	public interface ILocalizer
	{
		public Dictionary<string, string> Dictionary { get; }

		public IStringLocalizer<GlobalsLocalizer> Globals { get; }

		public IStringLocalizer<MessagesLocalizer> Messages { get; }

		public IStringLocalizer<ValidatorsLocalizer> Validates { get; }

		public IStringLocalizer<FieldsLocalizer> Fields { get; }

		public IStringLocalizer<ValueTextsLocalizer> ValueTexts { get; }
	}
}
