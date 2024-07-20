// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Common.Mapping;
using ErpManager.ERP.Fields;
using ErpManager.ERP.Globals;
using ErpManager.ERP.Messages;
using ErpManager.ERP.StringFormats;
using ErpManager.ERP.Validators;
using ErpManager.ERP.ValueTexts;

namespace ErpManager.ERP.Common.Localizer
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
