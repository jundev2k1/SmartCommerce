// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;
using ErpManager.Domain.Models;
using ErpManager.Persistence.Common.Utilities.Search;

namespace ErpManager.Persistence.Services
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

        #region Search
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchParams">Search parameters</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Search result model</returns>
        public SearchResultModel<ProductModel> Search(ProductSearchDto searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE)
        {
            if (string.IsNullOrEmpty(searchParams.BranchId)) return new SearchResultModel<ProductModel>();

            var condition = SearchConditionBuilder.ProductSearch(searchParams);
            var result = _productRepository.Search(condition, pageIndex, pageSize);
            return result;
        }
        #endregion

        #region Queries
        /// <summary>
        /// Get all product
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="isDeleted">Delete flag of product</param>
        /// <returns>Product list</returns>
        public ProductModel[] GetAllProduct(string branchId, bool isDeleted = false)
        {
            return _productRepository.GetAll(branchId, isDeleted);
        }

        /// <summary>
        /// Get product
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">Product id</param>
        /// <returns>Product model</returns>
        public ProductModel? GetProduct(string branchId, string productId)
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
        public bool Insert(ProductModel model)
        {
            model.DateCreated = DateTime.Now;
            model.DateChanged = null;
            return _productRepository.Insert(model);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Product model</param>
        /// <returns>Update status</returns>
        public bool Update(ProductModel model)
        {
            model.DateChanged = DateTime.Now;
            return _productRepository.Update(model);
        }

        /// <summary>
        /// Update description
        /// </summary>
        /// <param name="model">Product model</param>
        /// <returns>Is success</returns>
        public bool UpdateDescription(ProductModel model)
        {
            return _productRepository.UpdateDescription(model);
        }

        /// <summary>
        /// Delete temporary
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">Product id</param>
        /// <returns>Update status</returns>
        public bool TempDelete(string branchId, string productId)
        {
            var product = _productRepository.Get(branchId, productId);
            if (product == null) return false;

            product.DelFlg = true;
            return _productRepository.Update(product);
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
    }
}
