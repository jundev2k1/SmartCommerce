// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public partial class ProductService : ServiceBase, IProductService
	{
		#region Queries
		/// <summary>
		/// Get by criteria async
		/// </summary>
		/// <param name="inputParams">Input parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<ProductModel>> GetByCriteriaAsync(
			ProductFilterModel inputParams,
			int pageIndex,
			int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(inputParams.BranchId)) return new SearchResultModel<ProductModel>();

			var condition = FilterConditionBuilder.GetProductFilters(inputParams);
			var result = await _productRepository.GetByCriteriaAsync(condition, pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Get related products
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>A collection of related products</returns>
		public async Task<ProductModel[]> GetRelatedProductsAsync(string branchId, string productId)
		{
			return await _productRepository.GetRelatedProductsAsync(branchId, productId);
		}

		/// <summary>
		/// Get product
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Product model</returns>
		public async Task<ProductModel?> GetAsync(string branchId, string productId)
		{
			return await _productRepository.GetAsync(branchId, productId);
		}
		#endregion

		#region Command
		#endregion

		#region Extension
		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		public async Task<bool> IsExistAsync(string branchId, string productId)
		{
			return await _productRepository.IsExistAsync(branchId, productId);
		}
		#endregion
	}
}
