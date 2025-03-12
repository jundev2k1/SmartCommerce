// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class ProductRepository : RepositoryBase, IProductRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public ProductRepository(ApplicationDBContext dbContext, IFileLogger logger)
			: base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<ProductModel>> GetByCriteria(ProductFilterModel input)
		{
			var searchCondition = FilterConditionBuilder.GetProductFilters(input);

			// Search with query
			var query = _dbContext.Products
				.AsQueryable()
				.Where(searchCondition)
				.OrderByDynamic(input);

			// Handle get page information
			var queryCount = await query.CountAsync();
			var isSurplus = (queryCount % input.PageSize) > 0;
			var totalPage = queryCount / input.PageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var data = await query
				.Skip(input.PageSkip)
				.Take(input.PageSize)
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
		/// Get related products
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>A collection of related products</returns>
		public async Task<ProductModel[]> GetRelatedProducts(string branchId, string productId)
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
				.Where(item => (item.DelFlg == false)
					&& (item.Status != ProductStatusEnum.Pending)
					&& relatedIds.Contains(item.ProductId))
				.Select(product => product.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productIds">Product id list</param>
		/// <returns>Product model list</returns>
		public async Task<ProductModel[]> Gets(string branchId, string[] productIds)
		{
			var result = await _dbContext.Products
				.Where(product => (product.BranchId == branchId)
					&& productIds.Contains(product.ProductId))
				.Select(product => product.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>User model</returns>
		public async Task<ProductModel?> Get(string branchId, string productId)
		{
			var result = await _dbContext.Products.FirstOrDefaultAsync(product =>
				product.BranchId == branchId
				&& product.ProductId == productId
				&& product.DelFlg == false);
			return (result != null) ? result.MapToModel() : null;
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public async Task<bool> Insert(ProductModel model)
		{
			var result = await BeginTransactionAsync(async () =>
			{
				var product = await _dbContext.Products.FirstOrDefaultAsync(item =>
					item.BranchId == model.BranchId
					&& item.ProductId == model.ProductId);
				if (product != null) throw new NotExistInDBException() { ItemInfo = model.ProductId };

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
		public async Task<bool> Update(ProductModel model)
		{
			var result = await BeginTransactionAsync(async () =>
			{
				var product = await _dbContext.Products.FirstOrDefaultAsync(item =>
					item.BranchId == model.BranchId
					&& item.ProductId == model.ProductId);
				if (product == null) throw new NotExistInDBException() { ItemInfo = model.ProductId };

				product.MapToEntity(model);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string productId, Action<Product> UpdateAction)
		{
			var result = await BeginTransactionAsync( async () =>
			{
				var product = await _dbContext.Products.FirstOrDefaultAsync(item =>
					item.BranchId == branchId
					&& item.ProductId == productId);
				if (product == null) throw new NotExistInDBException() { ItemInfo = productId };

				UpdateAction(product);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Delete status</returns>
		public async Task<bool> Delete(string branchId, string productId)
		{
			var result = await BeginTransactionAsync(async () =>
			{
				var product = await _dbContext.Products.FirstOrDefaultAsync(item =>
					(item.BranchId == branchId)
					&& (item.ProductId == productId));
				if (product == null) throw new NotExistInDBException();

				_dbContext.Remove(product);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		public async Task<bool> IsExist(string branchId, string productId)
		{
			var result = await _dbContext.Products.AnyAsync(item =>
				item.BranchId == branchId
				&& item.ProductId == productId);
			return result;
		}
	}
}
