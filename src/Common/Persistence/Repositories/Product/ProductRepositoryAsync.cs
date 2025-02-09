// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public partial class ProductRepository : RepositoryBase, IProductRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<ProductModel>> GetByCriteriaAsync(
			Expression<Func<Product, bool>> expression,
			int pageIndex,
			int pageSize)
		{
			// Search with query
			var query = _dbContext.Products
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
				.Select(product => product.MapToModel())
				.ToArrayAsync();
			var result = new SearchResultModel<ProductModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};
			return result;
		}

		/// <summary>
		/// Get related products async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>A collection of related products</returns>
		public async Task<ProductModel[]> GetRelatedProductsAsync(string branchId, string productId)
		{
			// Get target product
			var product = await _dbContext.Products
				.AsNoTracking()
				.FirstOrDefaultAsync(product => product.BranchId == branchId
					&& product.ProductId == productId);

			// Convert related product to hashset for contrain condition
			var relatedIds = product?.RelatedProductId
				.Split(',', StringSplitOptions.RemoveEmptyEntries)
				.ToHashSet();
			if ((relatedIds == null) || (relatedIds.Any() == false))
				return Array.Empty<ProductModel>();

			var result = await _dbContext.Products
				.Where(item => item.DelFlg == false
					&& item.Status != ProductStatusEnum.Pending
					&& relatedIds.Contains(item.ProductId))
				.Select(product => product.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Gets async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productIds">Product id list</param>
		/// <returns>Product model list</returns>
		public async Task<ProductModel[]> GetsAsync(string branchId, string[] productIds)
		{
			var result = await _dbContext.Products
				.Where(product => (product.BranchId == branchId)
					&& productIds.Contains(product.ProductId))
				.Select(product => product.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Get async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>User model</returns>
		public async Task<ProductModel?> GetAsync(string branchId, string productId)
		{
			var result = await _dbContext.Products.FirstOrDefaultAsync(product =>
				product.BranchId == branchId
				&& product.ProductId == productId
				&& product.DelFlg == false);
			return (result != null) ? result.MapToModel() : null;
		}

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		public async Task<bool> IsExistAsync(string branchId, string productId)
		{
			var result = await _dbContext.Products.AnyAsync(item =>
				item.BranchId == branchId
				&& item.ProductId == productId);
			return result;
		}
	}
}
