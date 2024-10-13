// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public interface IProductRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<ProductModel> GetByCriteria(
			Expression<Func<Product, bool>> expression,
			int pageIndex,
			int pageSize);
		/// <summary>
		/// Get by criteria async
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<ProductModel>> GetByCriteriaAsync(
			Expression<Func<Product, bool>> expression,
			int pageIndex,
			int pageSize);

		/// <summary>
		/// Get related products
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Related products</returns>
		ProductModel[] GetRelatedProducts(string branchId, string productId);
		/// <summary>
		/// Get related products async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Related products</returns>
		Task<ProductModel[]> GetRelatedProductsAsync(string branchId, string productId);

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productIds">Product id list</param>
		/// <returns>Product model list</returns>
		ProductModel[] Gets(string branchId, string[] productIds);
		/// <summary>
		/// Gets async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productIds">Product id list</param>
		/// <returns>Product model list</returns>
		Task<ProductModel[]> GetsAsync(string branchId, string[] productIds);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Product model</returns>
		ProductModel? Get(string branchId, string productId);
		/// <summary>
		/// Get async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Product model</returns>
		Task<ProductModel?> GetAsync(string branchId, string productId);

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
		bool Update(string branchId, string productId, Action<Product> UpdateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Delete status</returns>
		bool Delete(string branchId, string productId);

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		bool IsExist(string branchId, string productId);
		/// <summary>
		/// Check is exist async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		Task<bool> IsExistAsync(string branchId, string productId);
	}
}
