// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public partial class ProductCategoryRepository : RepositoryBase, IProductCategoryRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public ProductCategoryRepository(ApplicationDBContext dbContext, IFileLogger logger)
			: base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<ProductCategoryModel>> GetByCriteria(ProductCategoryFilterModel input)
		{
			var searchCondition = FilterConditionBuilder.GetCategoryFilters(input);

			// Search with query
			var query = _dbContext.ProductCategories
				.AsQueryable()
				.Where(searchCondition)
				.OrderByDescending(product => product.DateCreated);

			// Handle get page information
			var queryCount = await query.CountAsync();
			var isSurplus = (queryCount % input.PageSize) > 0;
			var totalPage = queryCount / input.PageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var data = await query
				.Skip(input.PageSkip)
				.Take(input.PageSize)
				.Select(category => category.MapToModel())
				.ToArrayAsync();
			var result = new SearchResultModel<ProductCategoryModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};
			return result;
		}

		/// <summary>
		/// Get all root categories
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		public async Task<ProductCategoryModel[]> GetAllRootCategories(string branchId)
		{
			var result = await _dbContext.ProductCategories
				.Where(item => item.BranchId == branchId
					&& item.ParentId == Constants.FLG_CATEGORY_PARENT_CATEGORY_ROOT)
				.Select(item => item.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Category model list</returns>
		public async Task<ProductCategoryModel[]> Gets(string branchId, string[] categoryIds)
		{
			var result = await _dbContext.ProductCategories
				.Where(item => item.BranchId == branchId
					&& categoryIds.Contains(item.CategoryId))
				.Select(item => item.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		public async Task<ProductCategoryModel?> Get(string branchId, string categoryId)
		{
			var category = await _dbContext.ProductCategories
				.FirstOrDefaultAsync(cate =>
					(cate.DelFlg == false)
					&& (cate.BranchId == branchId)
					&& (cate.CategoryId == categoryId));
			return category?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Status insert</returns>
		public async Task<bool> Insert(ProductCategoryModel model)
		{
			var category = await Get(model.BranchId, model.CategoryId);
			if (category != null) return false;

			var result = await BeginTransaction(async () =>
			{
				var insertModel = model.MapToEntity();
				await _dbContext.AddAsync(insertModel);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status update</returns>
		public async Task<bool> Update(ProductCategoryModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var category = await _dbContext.ProductCategories
					.FirstOrDefaultAsync(cate =>
						(cate.BranchId == model.BranchId)
						&& (cate.CategoryId == model.CategoryId));
				if (category == null) throw new NotExistInDBException() { ItemInfo = model.CategoryId };

				category.MapToEntity(model);
				_dbContext.Update(category);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string categoryId, Action<ProductCategory> UpdateAction)
		{
			var result = await BeginTransaction(async () =>
			{
				var category = await _dbContext.ProductCategories
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.CategoryId == categoryId));
				if (category == null) throw new NotExistInDBException() { ItemInfo = categoryId };

				UpdateAction(category);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Delete items count</returns>
		public async Task<int> Delete(string branchId, string[] categoryIds)
		{
			var deleteCount = 0;
			var result = await BeginTransaction(async () =>
			{
				var categorys = await _dbContext.ProductCategories
					.Where(item => item.BranchId == branchId
						&& categoryIds.Contains(item.CategoryId))
					.ToArrayAsync();
				if (!categorys.Any())
					throw new NotExistInDBException() { ItemInfo = string.Join(',', categoryIds) };

				deleteCount = categorys.Count();
				_dbContext.RemoveRange(categorys);
				await _dbContext.SaveChangesAsync();
			});
			return deleteCount;
		}

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		public async Task<bool> IsExist(string branchId, string categoryId)
		{
			var result = await _dbContext.ProductCategories
				.AnyAsync(item => (item.BranchId == branchId)
					&& (item.CategoryId == categoryId));
			return result;
		}
	}
}
