// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public sealed class ProductService : ServiceBase, IProductService
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
		/// <param name="condition">Search condition</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<ProductModel>> GetByCriteria(ProductFilterModel condition)
		{
			if (string.IsNullOrEmpty(condition.BranchId)) return new ();

			var result = await _productRepository.GetByCriteria(condition);
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
			return await _productRepository.GetRelatedProducts(branchId, productId);
		}

		/// <summary>
		/// Get product
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Product model</returns>
		public async Task<ProductModel?> Get(string branchId, string productId)
		{
			return await _productRepository.Get(branchId, productId);
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
		public async Task<bool> Update(string branchId, string productId, Action<Product> updateAction)
		{
			return await _productRepository.Update(branchId, productId, updateAction);
		}

		/// <summary>
		/// Update description
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Is success</returns>
		public async Task<bool> UpdateDescription(ProductModel model)
		{
			var updateAction = (Product entity) =>
			{
				entity.Description = model.Description;
				entity.DateChanged = DateTime.Now;
			};
			return await _productRepository.Update(model.BranchId, model.ProductId, updateAction);
		}

		/// <summary>
		/// Update newest product images
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Actual product images</returns>
		public async Task<string?> UpdateNewestProductImages(string branchId, string productId)
		{
			var product = await Get(branchId, productId);
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
			var isSuccess = await _productRepository.Update(branchId, productId, updateAction);
			return isSuccess ? productImages : product.Images;
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Update status</returns>
		public async Task<bool> TempDelete(string branchId, string productId)
		{
			var result = await _productRepository.Update(
				branchId,
				productId,
				product => product.DelFlg = true);
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
			return await _productRepository.Delete(branchId, productId);
		}
		#endregion

		#region Extension
		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		public async Task<bool> IsExist(string branchId, string productId)
		{
			return await _productRepository.IsExist(branchId, productId);
		}
		#endregion
	}
}
