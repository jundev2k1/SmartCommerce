// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Entities;
using ErpManager.Domain.Models;

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
            var user = new UserModel
            {
                BranchID = userEntity.BranchID,
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
                RoleID = userEntity.RoleID,
            };
            return user;
        }
    }
}
