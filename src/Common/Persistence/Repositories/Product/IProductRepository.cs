// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A tuple includes data, total page and total record</returns>
        public (ProductModel[] Data, int TotalPage, int TotalRecord) Search(Expression<Func<Product, bool>> expression, int pageIndex, int pageSize);

        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="isDeleted">Delete flag of product</param>
        /// <returns>Product model list</returns>
        public ProductModel[] GetAll(string branchId, bool isDeleted);

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">Product id</param>
        /// <returns>Product model</returns>
        public ProductModel? Get(string branchId, string productId);

        /// <summary>
        /// Insert
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
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">Product id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string productId);
    }
}
