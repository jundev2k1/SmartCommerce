// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public partial class CategoryService : ServiceBase, ICategoryService
	{
		#region Constructor
		/// <summary>Context singleton</summary>
		private readonly ICategoryRepository _categoryRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		#endregion

		#region Queries
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="filterParams">Filter parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<CategoryModel> GetByCriteria(
			CategoryFilterModel filterParams,
			int pageIndex,
			int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(filterParams.BranchId)) return new SearchResultModel<CategoryModel>();

			var condition = FilterConditionBuilder.GetCategoryFilters(filterParams);
			var result = _categoryRepository.GetByCriteria(condition, pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Get all root categories
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		public CategoryModel[] GetAllRootCategories(string branchId)
		{
			return _categoryRepository.GetAllRootCategories(branchId);
		}

		/// <summary>
		/// Get category
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		public CategoryModel? Get(string branchId, string categoryId)
		{
			return _categoryRepository.Get(branchId, categoryId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Insert status</returns>
		public bool Insert(CategoryModel model)
		{
			model.DateCreated = DateTime.Now;
			model.DateChanged = null;
			var result = _categoryRepository.Insert(model);
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Update status</returns>
		public bool Update(CategoryModel model)
		{
			model.DateChanged = DateTime.Now;
			return _categoryRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, string categoryId, Action<Category> updateAction)
		{
			return _categoryRepository.Update(branchId, categoryId, updateAction);
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Update status</returns>
		public bool TempDelete(string branchId, string productId)
		{
			var product = _categoryRepository.Get(branchId, productId);
			if (product == null) return false;

			product.DelFlg = true;
			return _categoryRepository.Update(product);
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Delete status</returns>
		public int Delete(string branchId, string[] categoryIds)
		{
			return _categoryRepository.Delete(branchId, categoryIds);
		}
		#endregion

		#region Extension
		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		public bool IsExist(string branchId, string categoryId)
		{
			return _categoryRepository.IsExist(branchId, categoryId);
		}
		#endregion
	}
}
