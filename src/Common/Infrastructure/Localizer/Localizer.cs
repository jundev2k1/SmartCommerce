// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Resource.Localizers.Fields;
using SmartCommerce.Resource.Localizers.Globals;
using SmartCommerce.Resource.Localizers.Messages;
using SmartCommerce.Resource.Localizers.StringFormats;
using SmartCommerce.Resource.Localizers.Validators;
using SmartCommerce.Resource.Localizers.ValueTexts;

namespace SmartCommerce.Manager.Common.Localizer
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

			return ToDictionary(localizerCollection.SelectMany(localizer => localizer));
		}

		/// <summary>
		/// Convert to dictionary
		/// </summary>
		/// <param name="localizedList">Localized List</param>
		/// <returns>A dictionary</returns>
		private Dictionary<string, string> ToDictionary(IEnumerable<LocalizedString> localizedList)
		{
			return localizedList
				.Select(item => new KeyValuePair<string, string>(item.Name, item.Value))
				.ToDictionary(kp => kp.Key, kp => kp.Value);
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
