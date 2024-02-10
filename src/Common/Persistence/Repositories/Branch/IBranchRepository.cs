// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories.Branch
{
    public interface IBranchRepository
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>Branch model list</returns>
        public BranchModel[] GetAll();

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>Branch model</returns>
        public BranchModel? Get(string branchId);
    }
}
