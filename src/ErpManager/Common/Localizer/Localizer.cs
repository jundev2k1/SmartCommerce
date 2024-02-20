using ErpManager.ERP.Fields;
using ErpManager.ERP.Globals;
using ErpManager.ERP.Messages;
using ErpManager.ERP.Validators;
using ErpManager.ERP.ValueTexts;

namespace ErpManager.ERP.Common.Localizer
{
    public class Localizer : ILocalizer
    {
        public readonly IStringLocalizer<GlobalsLocalizer> _globalsLocalizer;
        public readonly IStringLocalizer<MessagesLocalizer> _messagesLocalizer;
        public readonly IStringLocalizer<ValidatorsLocalizer> _validatorsLocalizer;
        public readonly IStringLocalizer<FieldsLocalizer> _fieldsLocalizer;
        public readonly IStringLocalizer<ValueTextsLocalizer> _valueTextsLocalizer;

        public Localizer(
            IStringLocalizer<GlobalsLocalizer> globalsLocalizer,
            IStringLocalizer<MessagesLocalizer> messagesLocalizer,
            IStringLocalizer<ValidatorsLocalizer> validatorsLocalizer,
            IStringLocalizer<FieldsLocalizer> fieldsLocalizer,
            IStringLocalizer<ValueTextsLocalizer> valueTextsLocalizer)
        {
            _globalsLocalizer = globalsLocalizer;
            _messagesLocalizer = messagesLocalizer;
            _validatorsLocalizer = validatorsLocalizer;
            _fieldsLocalizer = fieldsLocalizer;
            _valueTextsLocalizer = valueTextsLocalizer;
        }

        public IStringLocalizer<GlobalsLocalizer> Globals => _globalsLocalizer;

        public IStringLocalizer<MessagesLocalizer> Messages => _messagesLocalizer;

        public IStringLocalizer<ValidatorsLocalizer> Validates => _validatorsLocalizer;

        public IStringLocalizer<FieldsLocalizer> Fields => _fieldsLocalizer;

        public IStringLocalizer<ValueTextsLocalizer> ValueTexts => _valueTextsLocalizer;
    }
}
