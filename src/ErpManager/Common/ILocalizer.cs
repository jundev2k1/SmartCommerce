// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Manager.Fields;
using ErpManager.Manager.Globals;
using ErpManager.Manager.Messages;
using ErpManager.Manager.Validators;
using ErpManager.Manager.ValueTexts;

namespace ErpManager.Manager.Common
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
