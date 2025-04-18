﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public interface IProductCategoryService
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<ProductCategoryModel>> GetByCriteria(ProductCategoryFilterModel input);

		/// <summary>
		/// Get all root categories
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		Task<ProductCategoryModel[]> GetWithChilds(string branchId);

		/// <summary>
		/// Get category
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		Task<ProductCategoryModel?> Get(string branchId, string categoryId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(ProductCategoryModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Update status</returns>
		Task<bool> Update(ProductCategoryModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, string categoryId, Action<ProductCategory> updateAction);

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Update status</returns>
		Task<bool> TempDelete(string branchId, string productId);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Delete status</returns>
		Task<int> Delete(string branchId, string[] categoryIds);

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		Task<bool> IsExist(string branchId, string categoryId);
	}
}
