// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public partial class CategoryRepository : RepositoryBase, ICategoryRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public CategoryRepository(ApplicationDBContext dbContext, IFileLogger logger) : base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<CategoryModel> GetByCriteria(Expression<Func<Category, bool>> expression, int pageIndex, int pageSize)
		{
			// Search with query
			var query = _dbContext.Categories
				.AsQueryable()
				.Where(expression)
				.OrderByDescending(product => product.DateCreated);

			// Handle get page information
			var queryCount = query.Count();
			var isSurplus = (queryCount % pageSize) > 0;
			var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var pageSkip = (pageIndex - 1) * pageSize;
			var data = query
				.Skip(pageSkip)
				.Take(pageSize)
				.Select(category => category.MapToModel())
				.ToArray();
			var result = new SearchResultModel<CategoryModel>
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
		public CategoryModel[] GetAllRootCategories(string branchId)
		{
			var result = _dbContext.Categories
				.Where(item => item.BranchId == branchId
					&& item.CategoryId == Constants.FLG_CATEGORY_PARENT_CATEGORY_ROOT)
				.Select(item => item.MapToModel())
				.ToArray();
			return result;
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Category model list</returns>
		public CategoryModel[] Gets(string branchId, string[] categoryIds)
		{
			var result = _dbContext.Categories
				.Where(item => item.BranchId == branchId
					&& categoryIds.Contains(item.CategoryId))
				.Select(item => item.MapToModel())
				.ToArray();
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		public CategoryModel? Get(string branchId, string categoryId)
		{
			var result = _dbContext.Categories
				.FirstOrDefault(category => category.DelFlg == false
					&& category.BranchId == branchId
					&& category.CategoryId == categoryId)
				?.MapToModel();
			return result;
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Status insert</returns>
		public bool Insert(CategoryModel model)
		{
			var category = Get(model.BranchId, model.CategoryId);
			if (category != null) return false;

			var result = BeginTransaction(() =>
			{
				var insertModel = model.MapToEntity();
				_dbContext.Add(insertModel);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status update</returns>
		public bool Update(CategoryModel model)
		{
			var result = BeginTransaction(() =>
			{
				var category = _dbContext.Categories.FirstOrDefault(
					cate => cate.BranchId == model.BranchId && cate.CategoryId == model.CategoryId);
				if (category == null) throw new NotExistInDBException() { ItemInfo = model.CategoryId };

				category.MapToEntity(model);
				_dbContext.Update(category);
				_dbContext.SaveChanges();
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
		public bool Update(string branchId, string categoryId, Action<Category> UpdateAction)
		{
			var result = BeginTransaction(() =>
			{
				var category = _dbContext.Categories.FirstOrDefault(
					item => item.BranchId == branchId && (item.CategoryId == categoryId));
				if (category == null) throw new NotExistInDBException() { ItemInfo = categoryId };

				UpdateAction(category);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Delete items count</returns>
		public int Delete(string branchId, string[] categoryIds)
		{
			var deleteCount = 0;
			var result = BeginTransaction(() =>
			{
				var categorys = _dbContext.Categories.Where(
					item => item.BranchId == branchId && categoryIds.Contains(item.CategoryId));
				if (!categorys.Any())
					throw new NotExistInDBException() { ItemInfo = string.Join(',', categoryIds) };

				deleteCount = categorys.Count();
				_dbContext.RemoveRange(categorys);
				_dbContext.SaveChanges();
			});
			return deleteCount;
		}

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		public bool IsExist(string branchId, string categoryId)
		{
			var result = _dbContext.Categories.Any(
				item => (item.BranchId == branchId) && (item.CategoryId == categoryId));
			return result;
		}
	}
}
