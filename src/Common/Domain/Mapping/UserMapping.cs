// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
    public static class UserMapping
    {
        /// <summary>
        /// Map to user model
        /// </summary>
        /// <param name="userEntity">User entity</param>
        /// <returns>User model</returns>
        public static UserModel MapToUserModel(this User userEntity)
        {
            var model = new UserModel
            {
                BranchId = userEntity.BranchId,
                UserId = userEntity.UserId,
                UserName = userEntity.UserName,
                Password = userEntity.Password,
                Avatar = userEntity.Avatar,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email,
                PhoneNumber = userEntity.PhoneNumber,
                Address1 = userEntity.Address1,
                Address2 = userEntity.Address2,
                Address3 = userEntity.Address3,
                Address4 = userEntity.Address4,
                Status = userEntity.Status,
                DelFlg = userEntity.DelFlg,
                Sex = userEntity.Sex,
                Birthday = userEntity.Birthday,
                DateCreated = userEntity.DateCreated,
                DateChanged = userEntity.DateChanged,
                CreatedBy = userEntity.CreatedBy,
                LastLogin = userEntity.LastLogin,
                LastChanged = userEntity.LastChanged,
                RoleId = userEntity.RoleId,
            };

            return model;
        }

        /// <summary>
        /// Map to user entity
        /// </summary>
        /// <param name="userModel">User model</param>
        /// <returns>User entity</returns>
        public static User MapToUserEntity(this UserModel userModel)
        {
            var entity = new User
            {
                BranchId = userModel.BranchId,
                UserId = userModel.UserId,
                UserName = userModel.UserName,
                Password = userModel.Password,
                Avatar = userModel.Avatar,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                PhoneNumber = userModel.PhoneNumber,
                Address1 = userModel.Address1,
                Address2 = userModel.Address2,
                Address3 = userModel.Address3,
                Address4 = userModel.Address4,
                Status = userModel.Status,
                DelFlg = userModel.DelFlg,
                Sex = userModel.Sex,
                Birthday = userModel.Birthday,
                DateCreated = userModel.DateCreated,
                DateChanged = userModel.DateChanged,
                CreatedBy = userModel.CreatedBy,
                LastLogin = userModel.LastLogin,
                LastChanged = userModel.LastChanged,
                RoleId = userModel.RoleId,
            };

            return entity;
        }
    }
}
