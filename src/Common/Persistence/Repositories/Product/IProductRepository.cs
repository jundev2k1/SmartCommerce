// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface IProductRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="condition">Search condition</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<ProductModel>> GetByCriteria(ProductFilterModel condition);

		/// <summary>
		/// Get related products
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Related products</returns>
		Task<ProductModel[]> GetRelatedProducts(string branchId, string productId);

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productIds">Product id list</param>
		/// <returns>Product model list</returns>
		Task<ProductModel[]> Gets(string branchId, string[] productIds);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Product model</returns>
		Task<ProductModel?> Get(string branchId, string productId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(ProductModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Update status</returns>
		Task<bool> Update(ProductModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, string productId, Action<Product> UpdateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Delete status</returns>
		Task<bool> Delete(string branchId, string productId);

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		Task<bool> IsExist(string branchId, string productId);
	}
}
