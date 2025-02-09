// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface ICategoryRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<CategoryModel> GetByCriteria(
			Expression<Func<Category, bool>> expression,
			int pageIndex,
			int pageSize);
		/// <summary>
		/// Get by criteria async
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<CategoryModel>> GetByCriteriaAsync(
			Expression<Func<Category, bool>> expression,
			int pageIndex,
			int pageSize);

		/// <summary>
		/// Get all root categories
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		CategoryModel[] GetAllRootCategories(string branchId);
		/// <summary>
		/// Get all root categories async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		Task<CategoryModel[]> GetAllRootCategoriesAsync(string branchId);

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Category model list</returns>
		CategoryModel[] Gets(string branchId, string[] categoryIds);
		/// <summary>
		/// Gets async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Category model list</returns>
		Task<CategoryModel[]> GetsAsync(string branchId, string[] categoryIds);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		CategoryModel? Get(string branchId, string categoryId);
		/// <summary>
		/// Get async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		Task<CategoryModel?> GetAsync(string branchId, string categoryId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Status insert</returns>
		bool Insert(CategoryModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status update</returns>
		bool Update(CategoryModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, string categoryId, Action<Category> UpdateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Delete items count</returns>
		int Delete(string branchId, string[] categoryIds);

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		bool IsExist(string branchId, string categoryId);
		/// <summary>
		/// Check is exist async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		Task<bool> IsExistAsync(string branchId, string categoryId);
	}
}
