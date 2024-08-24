// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public partial class ProductRepository : RepositoryBase, IProductRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public ProductRepository(DBContext dbContext, IFileLogger logger) : base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<ProductModel> GetByCriteria(
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
			var queryCount = query.Count();
			var isSurplus = (queryCount % pageSize) > 0;
			var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var pageSkip = (pageIndex - 1) * pageSize;
			var data = query
				.Skip(pageSkip)
				.Take(pageSize)
				.Select(product => product.MapToModel())
				.ToArray();
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
		public ProductModel[] GetRelatedProducts(string branchId, string productId)
		{
			// Get target product
			var product = _dbContext.Products
				.AsNoTracking()
				.FirstOrDefault(product => product.BranchId == branchId
					&& product.ProductId == productId);

			// Convert related product to hashset for contrain condition
			var relatedIds = product?.RelatedProductId
				.Split(',', StringSplitOptions.RemoveEmptyEntries)
				.ToHashSet();
			if ((relatedIds == null) || (relatedIds.Any() == false))
				return Array.Empty<ProductModel>();

			var result = _dbContext.Products
				.Where(item => item.DelFlg == false
					&& item.Status != ProductStatusEnum.Pending
					&& relatedIds.Contains(item.ProductId))
				.Select(product => product.MapToModel())
				.ToArray();
			return result;
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productIds">Product id list</param>
		/// <returns>Product model list</returns>
		public ProductModel[] Gets(string branchId, string[] productIds)
		{
			var result = _dbContext.Products
				.Where(product => (product.BranchId == branchId)
					&& productIds.Contains(product.ProductId))
				.Select(product => product.MapToModel())
				.ToArray();
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>User model</returns>
		public ProductModel? Get(string branchId, string productId)
		{
			var result = _dbContext.Products
				.FirstOrDefault(product => product.BranchId == branchId
					&& product.ProductId == productId
					&& product.DelFlg == false)
				?.MapToModel();
			return result;
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public bool Insert(ProductModel model)
		{
			var product = Get(model.BranchId, model.ProductId);
			if (product != null) return false;

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
		public bool Update(ProductModel model)
		{
			var result = BeginTransaction(() =>
			{
				var product = _dbContext.Products.FirstOrDefault(item =>
					item.BranchId == model.BranchId
					&& item.ProductId == model.ProductId);
				if (product == null) throw new NotExistInDBException() { ItemInfo = model.ProductId };

				product.MapToEntity(model);
				_dbContext.Update(product);
				_dbContext.SaveChanges();
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
		public bool Update(string branchId, string productId, Action<Product> UpdateAction)
		{
			var result = BeginTransaction(() =>
			{
				var product = _dbContext.Products.FirstOrDefault(item =>
					item.BranchId == branchId
					&& item.ProductId == productId);
				if (product == null) throw new NotExistInDBException() { ItemInfo = productId };

				UpdateAction(product);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Delete status</returns>
		public bool Delete(string branchId, string productId)
		{
			var result = BeginTransaction(() =>
			{
				var product = _dbContext.Products
					.FirstOrDefault(item => (item.BranchId == branchId) && (item.ProductId == productId));
				if (product == null) throw new NotExistInDBException();

				_dbContext.Remove(product);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		public bool IsExist(string branchId, string productId)
		{
			var result = _dbContext.Products.Any(item =>
				item.BranchId == branchId
				&& item.ProductId == productId);
			return result;
		}
	}
}
