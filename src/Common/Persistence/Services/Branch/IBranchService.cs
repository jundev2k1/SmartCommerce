// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
    public interface IBranchService
    {
        /// <summary>
        /// Get all branch
        /// </summary>
        /// <returns>A collection of branch</returns>
        public BranchModel?[] GetAllBranch();

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>Branch model</returns>
        public BranchModel? GetBranch(string branchId);
    }
}
