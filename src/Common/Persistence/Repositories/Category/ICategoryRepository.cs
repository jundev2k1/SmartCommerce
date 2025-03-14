// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface ICategoryRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<CategoryModel>> GetByCriteria(CategoryFilterModel input);

		/// <summary>
		/// Get all root categories
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		Task<CategoryModel[]> GetAllRootCategories(string branchId);

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Category model list</returns>
		Task<CategoryModel[]> Gets(string branchId, string[] categoryIds);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		Task<CategoryModel?> Get(string branchId, string categoryId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Status insert</returns>
		Task<bool> Insert(CategoryModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status update</returns>
		Task<bool> Update(CategoryModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, string categoryId, Action<Category> UpdateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Delete items count</returns>
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
