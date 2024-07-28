// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Manager.Common.Mapping;
using ErpManager.Manager.Fields;
using ErpManager.Manager.Globals;
using ErpManager.Manager.Messages;
using ErpManager.Manager.StringFormats;
using ErpManager.Manager.Validators;
using ErpManager.Manager.ValueTexts;

namespace ErpManager.Manager.Common.Localizer
{
	public sealed class Localizer : ILocalizer
	{
		private readonly IStringLocalizer<GlobalsLocalizer> _globalsLocalizer;
		private readonly IStringLocalizer<MessagesLocalizer> _messagesLocalizer;
		private readonly IStringLocalizer<ValidatorsLocalizer> _validatorsLocalizer;
		private readonly IStringLocalizer<FieldsLocalizer> _fieldsLocalizer;
		private readonly IStringLocalizer<ValueTextsLocalizer> _valueTextsLocalizer;
		private readonly IStringLocalizer<StringFormatsLocalizer> _stringFormatsLocalizer;

		public Localizer(
			IStringLocalizer<GlobalsLocalizer> globalsLocalizer,
			IStringLocalizer<MessagesLocalizer> messagesLocalizer,
			IStringLocalizer<ValidatorsLocalizer> validatorsLocalizer,
			IStringLocalizer<FieldsLocalizer> fieldsLocalizer,
			IStringLocalizer<ValueTextsLocalizer> valueTextsLocalizer,
			IStringLocalizer<StringFormatsLocalizer> stringFormatsLocalizer)
		{
			_globalsLocalizer = globalsLocalizer;
			_messagesLocalizer = messagesLocalizer;
			_validatorsLocalizer = validatorsLocalizer;
			_fieldsLocalizer = fieldsLocalizer;
			_valueTextsLocalizer = valueTextsLocalizer;
			_stringFormatsLocalizer = stringFormatsLocalizer;
		}

		public Dictionary<string, string> GetDictionary()
		{
			var localizerCollection = new List<IEnumerable<LocalizedString>>
			{
				this.Globals.GetAllStrings(),
				this.Messages.GetAllStrings(),
				this.Validates.GetAllStrings(),
				this.Fields.GetAllStrings(),
				this.ValueTexts.GetAllStrings(),
				this.StringFormats.GetAllStrings(),
			};

			return localizerCollection
				.SelectMany(localizer => localizer)
				.MapToDictionary();
		}

		public Dictionary<string, string> Dictionary => GetDictionary();

		public IStringLocalizer<GlobalsLocalizer> Globals => _globalsLocalizer;

		public IStringLocalizer<MessagesLocalizer> Messages => _messagesLocalizer;

		public IStringLocalizer<ValidatorsLocalizer> Validates => _validatorsLocalizer;

		public IStringLocalizer<FieldsLocalizer> Fields => _fieldsLocalizer;

		public IStringLocalizer<ValueTextsLocalizer> ValueTexts => _valueTextsLocalizer;

		public IStringLocalizer<StringFormatsLocalizer> StringFormats => _stringFormatsLocalizer;
	}
}
