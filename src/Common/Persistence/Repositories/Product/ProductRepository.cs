// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Models;

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
                .Select(product => product.MapToProductModel())
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
                .Select(product => product.MapToProductModel())
                .ToArray();

            return result;
        }

        /// <summary>
        /// Get related products
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">Product id</param>
        /// <param name="maxQuantity">Max quantity</param>
        /// <returns>A collection of related products</returns>
        public ProductModel[] GetRelatedProducts(string branchId, string productId, int maxQuantity = 0)
        {
            var product = _dbContext.Products.FirstOrDefault(product =>
                (product.BranchId == branchId)
                && (product.ProductId == productId));
            if (product == null) return Array.Empty<ProductModel>();

            var relatedProducts = _dbContext.Products
                .Where(product => (product.DelFlg == false) && (product.Status != ProductStatusEnum.Pending))
                .OrderBy(product => product.Address1 == product.Address1)
                .ThenByDescending(product => product.DateCreated)
                .ThenBy(product => product.Status)
                .Take(maxQuantity)
                .Select(product => product.MapToProductModel())
                .ToArray();
            return relatedProducts;
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
            var result = BeginTransaction(() =>
            {
                var product = _dbContext.Products
                    .FirstOrDefault(product => (product.BranchId == model.BranchId) && (product.ProductId == model.ProductId));
                if (product == null) throw new Exception();

                product.MapToUpdateProduct(model);
                _dbContext.Update(product);
                _dbContext.SaveChanges();
            });
            return result;
        }

        /// <summary>
        /// Update description
        /// </summary>
        /// <param name="model">Product model</param>
        /// <returns>Is success</returns>
        public bool UpdateDescription(ProductModel model)
        {
            var result = BeginTransaction(() =>
            {
                var product = _dbContext.Products
                    .FirstOrDefault(product => (product.BranchId == model.BranchId) && (product.ProductId == model.ProductId));
                if (product == null) throw new Exception();

                product.Description = model.Description;
                product.DateChanged = DateTime.Now;
                product.LastChanged = model.LastChanged;
                _dbContext.SaveChanges();
            });
            return result;
        }

        /// <summary>
        /// Update product image
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="productId">Product id</param>
        /// <param name="images">Images</param>
        /// <returns>Update status</returns>
        public bool UpdateProductImage(string branchId, string productId, string images)
        {
            var result = BeginTransaction(() =>
            {
                var product = _dbContext.Products
                    .FirstOrDefault(product => (product.BranchId == branchId) && (product.ProductId == productId));
                if (product == null) throw new Exception();

                product.Images = images;
                product.DateChanged = DateTime.Now;
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
