// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public partial class ProductCategoryService : ServiceBase, IProductCategoryService
	{
		#region Constructor
		/// <summary>Context singleton</summary>
		private readonly IProductCategoryRepository _categoryRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public ProductCategoryService(IProductCategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		#endregion

		#region Queries
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<ProductCategoryModel>> GetByCriteria(ProductCategoryFilterModel input)
		{
			if (string.IsNullOrEmpty(input.BranchId)) return new SearchResultModel<ProductCategoryModel>();

			var result = await _categoryRepository.GetByCriteria(input);
			return result;
		}

		/// <summary>
		/// Get all root categories
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Root category model list</returns>
		public async Task<ProductCategoryModel[]> GetWithChilds(string branchId)
		{
			return await _categoryRepository.GetAllRootCategories(branchId);
		}

		/// <summary>
		/// Get category
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Category model</returns>
		public async Task<ProductCategoryModel?> Get(string branchId, string categoryId)
		{
			return await _categoryRepository.Get(branchId, categoryId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Insert status</returns>
		public async Task<bool> Insert(ProductCategoryModel model)
		{
			model.DateCreated = DateTime.Now;
			model.DateChanged = null;
			var result = await _categoryRepository.Insert(model);
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(ProductCategoryModel model)
		{
			model.DateChanged = DateTime.Now;
			return await _categoryRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string categoryId, Action<ProductCategory> updateAction)
		{
			return await _categoryRepository.Update(branchId, categoryId, updateAction);
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category ID</param>
		/// <returns>Update status</returns>
		public async Task<bool> TempDelete(string branchId, string categoryId)
		{
			return await _categoryRepository.Update(
				branchId,
				categoryId,
				cate => cate.DelFlg = true);
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryIds">Category id list</param>
		/// <returns>Delete status</returns>
		public async Task<int> Delete(string branchId, string[] categoryIds)
		{
			return await _categoryRepository.Delete(branchId, categoryIds);
		}
		#endregion

		#region Extension
		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="categoryId">Category id</param>
		/// <returns>Is exist?</returns>
		public async Task<bool> IsExist(string branchId, string categoryId)
		{
			return await _categoryRepository.IsExist(branchId, categoryId);
		}
		#endregion
	}
}
