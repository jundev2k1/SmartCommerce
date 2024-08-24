// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public partial class CategoryService : ServiceBase, ICategoryService
	{
		#region Queries
		/// <summary>
		/// Get by criteria async
		/// </summary>
		/// <param name="filterParams">Filter parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<CategoryModel>> GetByCriteriaAsync(
			CategoryFilterModel filterParams,
			int pageIndex,
			int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(filterParams.BranchId)) return new SearchResultModel<CategoryModel>();

			var condition = FilterConditionBuilder.GetCategoryFilters(filterParams);
			var result = await _categoryRepository.GetByCriteriaAsync(condition, pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Get all root categories async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		public Task<CategoryModel[]> GetAllRootCategoriesAsync(string branchId)
		{
			return _categoryRepository.GetAllRootCategoriesAsync(branchId);
		}

		/// <summary>
		/// Get category async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		public async Task<CategoryModel?> GetAsync(string branchId, string categoryId)
		{
			return await _categoryRepository.GetAsync(branchId, categoryId);
		}
		#endregion

		#region Command
		#endregion

		#region Extension
		/// <summary>
		/// Check is exist async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		public async Task<bool> IsExistAsync(string branchId, string categoryId)
		{
			return await _categoryRepository.IsExistAsync(branchId, categoryId);
		}
		#endregion
	}
}
