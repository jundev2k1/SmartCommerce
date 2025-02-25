// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Common.Validators
{
	public sealed class ProductValidator : ValidatorBase<ProductModel>
	{
		public ProductValidator(ILocalizer localizer, IServiceFacade serviceFacade) : base(serviceFacade)
		{
			RuleFor(product => product.BranchId)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.MaximumLength(20).WithMessage(localizer.Validates["ErrorMsg_MaxLength"]);

			RuleFor(product => product.ProductId)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.Matches(Constants.REGEX_JUST_STRING_AND_NUMBER).WithMessage(localizer.Validates["ErrorMsg_ExistSpecialCharacter"])
				.Must((model, value) => IsUpdate(model.DateCreated) || BeNotExistProduct(model.BranchId, value)).WithMessage(localizer.Validates["ErrorMsg_ProductIdExist"])
				.MaximumLength(20).WithMessage(localizer.Validates["ErrorMsg_MaxLength"]);

			RuleFor(product => product.Name)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.MaximumLength(60).WithMessage(localizer.Validates["ErrorMsg_MaxLength"]);

			RuleFor(product => product.Images)
				.Must(MustBeValidImages).WithMessage("Product image are in wrong format")
				.MaximumLength(4000).WithMessage(localizer.Validates["ErrorMsg_MaxLength"]);

			RuleFor(product => product.Address1)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.MaximumLength(60).WithMessage(localizer.Validates["ErrorMsg_MaxLength"])
				.Must((model, value) => string.IsNullOrEmpty(value) || BeProvince(value))
					.WithMessage(localizer.Validates["ErrorMsg_Address_IsNotValid"]);

			RuleFor(product => product.Address2)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.MaximumLength(60).WithMessage(localizer.Validates["ErrorMsg_MaxLength"])
				.Must((model, value) => string.IsNullOrEmpty(value) || BeDistrict(model, value))
					.WithMessage(localizer.Validates["ErrorMsg_Address_IsNotValid"]);

			RuleFor(product => product.Address3)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.MaximumLength(60).WithMessage(localizer.Validates["ErrorMsg_MaxLength"])
				.Must((model, value) => string.IsNullOrEmpty(value) || BeCommune(model, value))
					.WithMessage(localizer.Validates["ErrorMsg_Address_IsNotValid"]);

			RuleFor(product => product.Address4)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.MaximumLength(60).WithMessage(localizer.Validates["ErrorMsg_MaxLength"]);

			RuleFor(product => product.Price1)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.GreaterThanOrEqualTo(0).WithMessage(localizer.Validates["ErrorMsg_CannotNegative"]);

			RuleFor(product => product.Price2)
				.GreaterThanOrEqualTo(0).WithMessage(localizer.Validates["ErrorMsg_CannotNegative"]);

			RuleFor(product => product.Price3)
				.GreaterThanOrEqualTo(0).WithMessage(localizer.Validates["ErrorMsg_CannotNegative"]);

			RuleFor(product => product.DisplayPrice)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.IsInEnum().WithMessage(localizer.Validates["ErrorMsg_IsNotEnum"]);

			RuleFor(product => product.Status)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.IsInEnum().WithMessage(localizer.Validates["ErrorMsg_IsNotEnum"]);

			RuleFor(product => product.Size1)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.GreaterThanOrEqualTo(0).WithMessage(localizer.Validates["ErrorMsg_CannotNegative"]);

			RuleFor(product => product.Size2)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.GreaterThanOrEqualTo(0).WithMessage(localizer.Validates["ErrorMsg_CannotNegative"]);

			RuleFor(product => product.Size3)
				.NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
				.GreaterThanOrEqualTo(0).WithMessage(localizer.Validates["ErrorMsg_CannotNegative"]);

			RuleFor(product => product.TakeOverId)
				.MaximumLength(30).WithMessage(localizer.Validates["ErrorMsg_MaxLength"])
				.Must((model, value) => string.IsNullOrEmpty(value) || BeValidUser(model.BranchId, value))
					.WithMessage(localizer.Validates["ErrorMsg_UserNotExist"]);

			RuleFor(product => product.RelatedProductId)
				.MaximumLength(4000).WithMessage(localizer.Validates["ErrorMsg_MaxLength"])
				.Must((model, value) => string.IsNullOrEmpty(value) || BeProductRelatedFormat(model.BranchId, value))
					.WithMessage(localizer.Validates["ErrorMsg_ProductNotExist"]);
		}

		/// <summary>
		/// Be district
		/// </summary>
		/// <param name="model">Product model</param>
		/// <param name="value">Value</param>
		/// <returns>Is district</returns>
		public bool BeDistrict(ProductModel model, string value)
		{
			var districtGroups = AddressProvider.Instance.Districts;
			if (string.IsNullOrEmpty(model.Address1) == false)
			{
				districtGroups = districtGroups.Where(address => address.ProvinceId.Equals(model.Address1)).ToList();
			}

			var result = districtGroups.SelectMany(address => address.Items).Any(address => address.DistrictId.Equals(value));
			return result;
		}

		/// <summary>
		/// Be commune
		/// </summary>
		/// <param name="model">Product model</param>
		/// <param name="value">Value</param>
		/// <returns>Is commune</returns>
		public bool BeCommune(ProductModel model, string value)
		{
			var communeGroupList = AddressProvider.Instance.Communes;
			if (string.IsNullOrEmpty(model.Address1) == false)
			{
				communeGroupList = communeGroupList.Where(address => address.ProvinceId.Equals(model.Address1)).ToList();
			}

			var communeGroups = communeGroupList.SelectMany(address => address.Items);
			if (string.IsNullOrEmpty(model.Address2) == false)
			{
				communeGroups = communeGroups.Where(address => address.DistrictId.Equals(model.Address2));
			}

			var result = communeGroups.SelectMany(address => address.Items).Any(address => address.CommuneId.Equals(value));
			return result;
		}

		/// <summary>
		/// Be product related format
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="value">Related product id (string)</param>
		/// <returns>Is valid</returns>
		public bool BeProductRelatedFormat(string branchId, string value)
		{
			var productIds = value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			var result = productIds.All(id => _serviceFacade.Products.IsExist(branchId, id).Result);
			return result;
		}
	}
}
