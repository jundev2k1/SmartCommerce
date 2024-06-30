// Copyright (c) 2024 - Jun Dev. All rights reserved

using System.Buffers;

namespace ErpManager.Persistence.Repositories
{
	public sealed class ProductRepository : RepositoryBase, IProductRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public ProductRepository(DBContext dbContext, IFileLogger logger) : base(dbContext, logger)
		{
		}

		/// <summary>
		/// Search
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<ProductModel> Search(Expression<Func<Product, bool>> expression, int pageIndex, int pageSize)
		{
			var query = _dbContext.Products
				.AsQueryable()
				.Where(expression)
				.OrderByDescending(product => product.DateCreated);

			var queryCount = query.Count();
			var isSurplus = (queryCount % pageSize) > 0;
			var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

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
		/// Get all
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="isDeleted">Delete flag of product</param>
		/// <returns>A collection of product</returns>
		public ProductModel[] GetAll(string branchId, bool isDeleted)
		{
			var result = _dbContext.Products
				.Where(product =>
					product.BranchId == branchId
					&& product.DelFlg == isDeleted)
				.OrderByDescending(product => product.DateCreated)
				.Select(product => product.MapToModel())
				.ToArray();

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
			var product = _dbContext.Products.FirstOrDefault(product =>
				(product.BranchId == branchId)
				&& (product.ProductId == productId));
			var relatedIds = product?.RelatedProductId.Split(',', StringSplitOptions.RemoveEmptyEntries);
			if ((relatedIds == null) || (relatedIds.Any() == false)) return Array.Empty<ProductModel>();

			var relatedProducts = _dbContext.Products
				.Where(item => item.DelFlg == false
					&& item.Status != ProductStatusEnum.Pending
					&& relatedIds.Contains(item.ProductId))
				.Select(product => product.MapToModel())
				.ToArray();
			return relatedProducts;
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
				.Where(product => (product.BranchId == branchId) && productIds.Contains(product.ProductId))
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
				.FirstOrDefault(product =>
					(product.BranchId == branchId)
					&& (product.ProductId == productId)
					&& product.DelFlg == false);

			return result?.MapToModel();
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
				var product = _dbContext.Products
					.FirstOrDefault(product => (product.BranchId == model.BranchId) && (product.ProductId == model.ProductId));
				if (product == null) throw new NotExistInDBException();

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
				var product = _dbContext.Products.FirstOrDefault(product =>
					(product.BranchId == branchId)
					&& (product.ProductId == productId));
				if (product == null) throw new NotExistInDBException();

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
			return _dbContext.Products.Any(item =>
				(item.BranchId == branchId)
				&& (item.ProductId == productId));
		}
	}
}
