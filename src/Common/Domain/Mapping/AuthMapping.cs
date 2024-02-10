// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
    public static class AuthMapping
    {
        /// <summary>
        /// Map to operator model
        /// </summary>
        /// <param name="userModel">User model</param>
        /// <param name="roleModel">Role model</param>
        /// <returns>Operator model</returns>
        public static OperatorModel? MapToOperatorModel(UserModel userModel, RoleModel roleModel)
        {
            if (userModel.BranchId != roleModel.BranchId) return null;

            var model = new OperatorModel
            {
                BranchId = roleModel.BranchId,
                Profile = userModel,
                Permission = roleModel.Permission,
            };

            return model;
        }
    }
}
