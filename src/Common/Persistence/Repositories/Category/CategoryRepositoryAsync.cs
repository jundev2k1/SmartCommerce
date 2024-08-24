// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public partial class CategoryRepository : RepositoryBase, ICategoryRepository
	{
		/// <summary>
		/// Get by criteria async
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<CategoryModel>> GetByCriteriaAsync(
			Expression<Func<Category, bool>> expression,
			int pageIndex,
			int pageSize)
		{
			// Search with query
			var query = _dbContext.Categories
				.AsQueryable()
				.Where(expression)
				.OrderByDescending(product => product.DateCreated);

			// Handle get page information
			var queryCount = await query.CountAsync();
			var isSurplus = (queryCount % pageSize) > 0;
			var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var pageSkip = (pageIndex - 1) * pageSize;
			var data = await query
				.Skip(pageSkip)
				.Take(pageSize)
				.Select(category => category.MapToModel())
				.ToArrayAsync();
			var result = new SearchResultModel<CategoryModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};
			return result;
		}

		/// <summary>
		/// Get all root categories async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		public async Task<CategoryModel[]> GetAllRootCategoriesAsync(string branchId)
		{
			var result = await _dbContext.Categories
				.Where(item => item.BranchId == branchId
					&& item.CategoryId == Constants.FLG_CATEGORY_PARENT_CATEGORY_ROOT)
				.Select(item => item.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Gets async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Category model list</returns>
		public async Task<CategoryModel[]> GetsAsync(string branchId, string[] categoryIds)
		{
			var result = await _dbContext.Categories
				.Where(item => item.BranchId == branchId
					&& categoryIds.Contains(item.CategoryId))
				.Select(item => item.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Get async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		public async Task<CategoryModel?> GetAsync(string branchId, string categoryId)
		{
			var category = await _dbContext.Categories.FirstOrDefaultAsync(cate =>
				cate.DelFlg == false
				&& cate.BranchId == branchId
				&& cate.CategoryId == categoryId);
			var result = category != null
				? category.MapToModel()
				: null;
			return result;
		}

		/// <summary>
		/// Check is exist async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		public async Task<bool> IsExistAsync(string branchId, string categoryId)
		{
			var result = await _dbContext.Categories.AnyAsync(
				item => (item.BranchId == branchId) && (item.CategoryId == categoryId));
			return result;
		}
	}
}
