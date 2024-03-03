// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
    public static class BranchMapping
    {
        /// <summary>
        /// Map to branch model
        /// </summary>
        /// <param name="branchEntity">Branch entity</param>
        /// <returns>Branch model</returns>
        public static BranchModel MapToBranchModel(this Branch branchEntity)
        {
            var model = new BranchModel
            {
                BranchId = branchEntity.BranchId,
                Name = branchEntity.Name,
                Avatar = branchEntity.Avatar,
                Status = branchEntity.Status,
                DateCreated = branchEntity.DateCreated,
                LastChanged = branchEntity.LastChanged,
            };

            return model;
        }

        /// <summary>
        /// Map to branch entity
        /// </summary>
        /// <param name="branchModel">Branch model</param>
        /// <returns>Branch entity</returns>
        public static Branch MapToRoleEntity(this BranchModel branchModel)
        {
            var entity = new Branch
            {
                BranchId = branchModel.BranchId,
                Name = branchModel.Name,
                Avatar = branchModel.Avatar,
                Status = branchModel.Status,
                DateCreated = branchModel.DateCreated,
                LastChanged = branchModel.LastChanged,
            };

            return entity;
        }
    }
}
