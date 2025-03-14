// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Resource.Localizers.Fields;
using SmartCommerce.Resource.Localizers.Globals;
using SmartCommerce.Resource.Localizers.Messages;
using SmartCommerce.Resource.Localizers.Validators;
using SmartCommerce.Resource.Localizers.ValueTexts;

namespace SmartCommerce.Infrastructure.Interface
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
