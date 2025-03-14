// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Common.ValueText
{
	public sealed class ValueTextManager
	{
		// Dependency local variable
		private readonly ILocalizer _localizer;
		// Datasource
		private ValueTextModel _datasource = new ValueTextModel();

		/// <summary>
		/// Constructor
		/// </summary>
		public ValueTextManager(ILocalizer localizer)
		{
			_localizer = localizer;
			Initialize();
		}

		private void Initialize()
		{
			var jsonData = File.ReadAllText($"{Environment.CurrentDirectory}{Constants.SCM_FILE_PATH_VALUETEXT_SETTING}");
			_datasource = JsonConvert.DeserializeObject<ValueTextModel>(jsonData) ?? new ValueTextModel();
		}

		public ValueTextItemModel[] GetGroupValueText(
			Func<ValueTextModel, Dictionary<string, ValueTextItemModel[]>> getTargetValueText,
			string field)
		{
			var targetGroup = getTargetValueText(_datasource);
			if (!targetGroup.ContainsKey(field)) throw new Exception();

			return targetGroup[field];
		}

		public ValueTextItemModel? GetValueText(
			Func<ValueTextModel, Dictionary<string, ValueTextItemModel[]>> getTargetValueText,
			string field,
			string value)
		{
			var groupField = GetGroupValueText(getTargetValueText, field);
			return groupField.FirstOrDefault(item => item.Value == value);
		}

		public List<SelectListItem> GetSelectList(
			Func<ValueTextModel, Dictionary<string, ValueTextItemModel[]>> getTargetValueText,
			string field,
			string defaultValue = "")
		{
			// Func map select item
			var mapToSelectItem = (ValueTextItemModel item) =>
			{
				return new SelectListItem
				{
					Text = _localizer.ValueTexts[item.LocalizerKey].Value,
					Value = item.Value,
					Selected = item.Value == defaultValue
				};
			};

			// Get data for dropdownlist
			var data = GetGroupValueText(getTargetValueText, field);
			var result = data.Select(mapToSelectItem).ToList();
			return result;
		}
	}
}
