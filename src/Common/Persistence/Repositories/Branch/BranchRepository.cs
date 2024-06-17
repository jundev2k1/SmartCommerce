// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public sealed class BranchRepository : RepositoryBase, IBranchRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public BranchRepository(DBContext dbContext, IFileLogger logger) : base(dbContext, logger)
        {
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>A collection of branch</returns>
        public BranchModel[] GetAll()
        {
            var result = _dbContext.Branches
                .Where(branch => branch.Status == BranchStatusEnum.Active)
                .Select(branch => branch.MapToModel())
                .ToArray();

            return result;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>Branch model</returns>
        public BranchModel? Get(string branchId)
        {
            var result = _dbContext.Branches
                .FirstOrDefault(branch => (branch.BranchId == branchId));

            return result?.MapToModel();
        }
    }
}
