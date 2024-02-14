// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public sealed class ProductRepository : RepositoryBase, IProductRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A tuple includes data, total page and total record</returns>
        public (ProductModel[] Data, int TotalPage, int TotalRecord) Search(Expression<Func<Product, bool>> expression, int pageIndex, int pageSize)
        {
            var query = _dbContext.Products
                .AsQueryable()
                .Where(expression);

            var queryCount = query.Count();
            var isSurplus = (queryCount % pageSize) > 0;
            var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

            var pageSkip = (pageIndex - 1) * pageSize;
            var data = query
                .Skip(pageSkip)
                .Take(pageSize)
                .Select(product => product.MapToProductModel())
                .ToArray();

            return (data, totalPage, queryCount);
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
                .Select(product => product.MapToProductModel())
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

            return result?.MapToProductModel();
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
                var insertModel = model.MapToProductEntity();
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
            var product = Get(model.BranchId, model.ProductId);
            if (product == null) return false;

            // Reset date created
            model.DateCreated = product.DateCreated;

            var result = BeginTransaction(() =>
            {
                var updateModel = model.MapToProductEntity();
                _dbContext.Update(updateModel);
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
            var user = Get(branchId, productId);
            if (user == null) return false;

            var result = BeginTransaction(() =>
            {
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
            });
            return result;
        }
    }
}
