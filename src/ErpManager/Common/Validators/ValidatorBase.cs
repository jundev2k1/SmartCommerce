// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Validators
{
	public class ValidatorBase<T> : AbstractValidator<T>
	{
		protected readonly IServiceFacade _serviceFacade;
		public ValidatorBase(IServiceFacade serviceFacade)
		{
			_serviceFacade = serviceFacade;
		}

		/// <summary>
		/// Must be valid images
		/// </summary>
		/// <returns>Is valid value</returns>
		protected bool MustBeValidImages(string value)
		{
			if (string.IsNullOrEmpty(value)) return true;

			bool ValidFileName(string fileName)
			{
				if (string.IsNullOrEmpty(fileName)) return false;

				var fileNameParts = fileName.Split('.');
				if (fileNameParts.Length != 2
					|| !Constants.CONST_DATA_VALID_IMAGE_EXTENSIONS.Contains(fileNameParts[1])
					|| string.IsNullOrEmpty(fileNameParts[0])) return false;

				return true;
			}

			var fileNames = value.Split(',');
			return fileNames.All(file => ValidFileName(file));
		}

		/// <summary>
		/// Be province
		/// </summary>
		/// <param name="value">Value</param>
		/// <returns>Is province</returns>
		protected bool BeProvince(string value)
		{
			return AddressProvider.Instance.Provinces.Any(address => address.ProvinceId.Equals(value));
		}

		/// <summary>
		/// Be valid user (User must exist in database)
		/// </summary>
		/// <param name="userId">User id</param>
		/// <returns>Be valid user</returns>
		protected bool BeValidUser(string branchId, string userId)
		{
			return _serviceFacade.Users.Get(branchId, userId) != null;
		}

		/// <summary>
		/// Be not exist product id (Product must not exist in database)
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is not exist</returns>
		protected bool BeNotExistProduct(string branchId, string productId)
		{
			var result = _serviceFacade.Products.Get(branchId, productId) == null;
			return result;
		}

		/// <summary>
		/// Is update
		/// </summary>
		/// <param name="dateCreated">Date created</param>
		/// <returns>Is update</returns>
		protected bool IsUpdate(DateTime? dateCreated)
		{
			return dateCreated != null;
		}
	}
}
