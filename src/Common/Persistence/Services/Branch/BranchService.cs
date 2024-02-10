// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Persistence.Repositories.Branch;

namespace ErpManager.Persistence.Services
{
    public class BranchService : ServiceBase, IBranchService
    {
        #region Constructor
        /// <summary>Context singleton</summary>
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        #endregion

        #region Queries
        /// <summary>
        /// Get all branch
        /// </summary>
        /// <returns>A collection of branch</returns>
        public BranchModel[] GetAllBranch()
        {
            return _branchRepository.GetAll();
        }

        /// <summary>
        /// Get branch
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>Branch model</returns>
        public BranchModel? GetBranch(string branchId)
        {
            return _branchRepository.Get(branchId);
        }
        #endregion    
    }
}
