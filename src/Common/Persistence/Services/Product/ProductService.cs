// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public partial class ProductService : ServiceBase, IProductService
	{
		#region Constructor
		/// <summary>Context singleton</summary>
		private readonly IProductRepository _productRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		#endregion

		#region Queries
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="inputParams">Input parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<ProductModel> GetByCriteria(ProductFilterModel inputParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(inputParams.BranchId)) return new SearchResultModel<ProductModel>();

			var condition = FilterConditionBuilder.GetProductFilters(inputParams);
			var result = _productRepository.GetByCriteria(condition, pageIndex, pageSize);
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
			return _productRepository.GetRelatedProducts(branchId, productId);
		}

		/// <summary>
		/// Get product
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Product model</returns>
		public ProductModel? Get(string branchId, string productId)
		{
			return _productRepository.Get(branchId, productId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Insert status</returns>
		public async Task<bool> Insert(ProductModel model)
		{
			model.DateCreated = DateTime.Now;
			model.DateChanged = null;
			return await _productRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(ProductModel model)
		{
			model.DateChanged = DateTime.Now;
			return await _productRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, string productId, Action<Product> updateAction)
		{
			return _productRepository.Update(branchId, productId, updateAction);
		}

		/// <summary>
		/// Update description
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Is success</returns>
		public bool UpdateDescription(ProductModel model)
		{
			var updateAction = (Product entity) =>
			{
				entity.Description = model.Description;
				entity.DateChanged = DateTime.Now;
			};
			return _productRepository.Update(model.BranchId, model.ProductId, updateAction);
		}

		/// <summary>
		/// Update newest product images
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Actual product images</returns>
		public string? UpdateNewestProductImages(string branchId, string productId)
		{
			var product = Get(branchId, productId);
			if (product == null) return null;

			var fileManager = new FileManager(
				files: Array.Empty<IFormFile>(),
				@enum: UploadEnum.ProductImage,
				fileName: productId);
			var actualFileName = fileManager.GetAllActualFileName();
			var productImages = string.Join(",", actualFileName);

			var updateAction = (Product item) =>
			{
				item.Images = productImages;
				item.DateChanged = DateTime.Now;
			};
			var isSuccess = _productRepository.Update(branchId, productId, updateAction);
			return isSuccess ? productImages : product.Images;
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Update status</returns>
		public bool TempDelete(string branchId, string productId)
		{
			var result = _productRepository.Update(
				branchId,
				productId,
				(product) => product.DelFlg = true);
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
			return _productRepository.Delete(branchId, productId);
		}
		#endregion

		#region Extension
		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		public bool IsExist(string branchId, string productId)
		{
			return _productRepository.IsExist(branchId, productId);
		}
		#endregion
	}
}
