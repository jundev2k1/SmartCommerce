// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Fields;
using ErpManager.ERP.Globals;
using ErpManager.ERP.Messages;
using ErpManager.ERP.Validators;
using ErpManager.ERP.ValueTexts;

namespace ErpManager.ERP.Common
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
