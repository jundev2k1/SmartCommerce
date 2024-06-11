// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Products.Controllers
{
    public class ProductBaseController : BaseController
    {
        protected readonly ValueTextManager _valueTextManager;

        public ProductBaseController(
            IServiceFacade serviceFacade,
            SessionManager sessionManager,
            ILocalizer localizer,
            IFileLogger logger,
            ValueTextManager valueTextManager) : base(serviceFacade, sessionManager, localizer, logger)
        {
            _valueTextManager = valueTextManager;
        }

        /// <summary>
        /// Get init dropdown list items
        /// </summary>
        /// <param name="formInput">Form input</param>
        /// <returns>Dropdown list item collection</returns>
        protected Dictionary<string, List<SelectListItem>> GetInitDropdownListItems(ProductModel formInput)
        {
            var ddlCollection = new Dictionary<string, List<SelectListItem>>();

            // Add init for take over id
            if (string.IsNullOrEmpty(formInput.TakeOverId) == false)
            {
                var user = _serviceFacade.Users.GetUser(this.OperatorBranchId, formInput.TakeOverId);
                if (user != null)
                {
                    var propName = formInput.Properties.GetName(prop => prop.TakeOverId);
                    var ddlOptions = new List<SelectListItem>
                    {
                        new SelectListItem { Text = $"{user.UserId}. {user.FullName}", Value = formInput.TakeOverId, Selected = true }
                    };
                    ddlCollection.Add(propName, ddlOptions);
                }
            }
            // Add init for product status
            var ddlStatus = _valueTextManager.GetSelectList(
                group => group.Product,
                Constants.VALUETEXT_FIELD_PRODUCT_STATUS,
                formInput.Status.GetStringValue());
            var statusPropertyName = formInput.Properties.GetName(property => property.Status);
            ddlCollection.Add(statusPropertyName, ddlStatus);

            // Add init for display price
            var ddlDisplayPrice = _valueTextManager.GetSelectList(
                group => group.Product,
                Constants.VALUETEXT_FIELD_PRODUCT_DISPLAY_PRICE,
                formInput.DisplayPrice.GetStringValue());
            var displayPricePropertyName = formInput.Properties.GetName(property => property.DisplayPrice);
            ddlCollection.Add(displayPricePropertyName, ddlDisplayPrice);

            return ddlCollection;
        }
    }
}
