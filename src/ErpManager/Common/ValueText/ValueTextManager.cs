// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.ValueText
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
            var jsonData = File.ReadAllText($"{Environment.CurrentDirectory}{Constants.ERP_FILE_PATH_VALUETEXT_SETTING}");
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
            string defaultValue = "",
            bool includeEmptyFlg = false)
        {
            var data = GetGroupValueText(getTargetValueText, field);
            var result = new List<SelectListItem>();

            // Add empty field if include empty flag is on 
            if (includeEmptyFlg)
            {
                result.Add(new SelectListItem
                {
                    Text = string.Empty,
                    Value = string.Empty,
                    Selected = string.IsNullOrEmpty(defaultValue)
                });
            }

            // Add items
            foreach (var item in data)
            {
                var textContent = !string.IsNullOrEmpty(item.LocalizerKey)
                    ? _localizer.ValueTexts[item.LocalizerKey]
                    : item.Text;
                var selectItem = new SelectListItem
                {
                    Text = textContent,
                    Value = item.Value,
                    Selected = item.Value == defaultValue
                };
                result.Add(selectItem);
            }

            return result;
        }
    }
}
