// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Get all product
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="isDeleted">Delete flag of product</param>
        /// <returns>A collection of product</returns>
        public ProductModel[] GetAllProduct(string branchId, bool isDeleted = true);

        /// <summary>
        /// Get product
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">Product id</param>
        /// <returns>product model</returns>
        public ProductModel? GetProduct(string branchId, string productId);

        /// <summary>
        /// Insert product
        /// </summary>
        /// <param name="model">Product model</param>
        /// <returns>Insert status</returns>
        public bool Insert(ProductModel model);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Product model</param>
        /// <returns>Update status</returns>
        public bool Update(ProductModel model);

        /// <summary>
        /// Delete temporary
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">product id</param>
        /// <remarks>Update delete flag to "true"</remarks>
        /// <returns>Delete status</returns>
        public bool TempDelete(string branchId, string productId);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">ProductId id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string productId);
    }
}
