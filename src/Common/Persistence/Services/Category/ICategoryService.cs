// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public interface ICategoryService
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="filterParams">Filter parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<CategoryModel> GetByCriteria(
			CategoryFilterModel filterParams,
			int pageIndex,
			int pageSize = Constants.DEFAULT_PAGE_SIZE);
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="filterParams">Filter parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<CategoryModel>> GetByCriteriaAsync(
			CategoryFilterModel filterParams,
			int pageIndex,
			int pageSize = Constants.DEFAULT_PAGE_SIZE);

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
		/// Get category
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		CategoryModel? Get(string branchId, string categoryId);
		/// <summary>
		/// Get category async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		Task<CategoryModel?> GetAsync(string branchId, string categoryId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Insert status</returns>
		bool Insert(CategoryModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Update status</returns>
		bool Update(CategoryModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, string categoryId, Action<Category> updateAction);

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Update status</returns>
		bool TempDelete(string branchId, string productId);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Delete status</returns>
		int Delete(string branchId, string[] categoryIds);

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		bool IsExist(string branchId, string categoryId);
		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		Task<bool> IsExistAsync(string branchId, string categoryId);
	}
}
