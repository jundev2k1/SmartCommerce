// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public sealed class BranchRepository : RepositoryBase, IBranchRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public BranchRepository(DBContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Get all branch
        /// </summary>
        /// <returns>A collection of branch</returns>
        public BranchModel[] GetAll()
        {
            var result = _dbContext.Branches
                .Where(branch => branch.Status == BranchStatusEnum.Active)
                .Select(branch => branch.MapToBranchModel())
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

            return result?.MapToBranchModel();
        }
    }
}
