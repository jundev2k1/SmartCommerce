// Copyright (c) 2024 - Jun Dev. All rights reserved

using Persistence.Repositories.User;

namespace Persistence.Services
{
    public class UserService : ServiceBase, IUserService
    {
        /// <summary>Context singleton</summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>User list</returns>
        public UserModel[] GetAllUser(string branchId)
        {
            return _userRepository.GetAll(branchId);
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? GetUser(string branchId, string userId)
        {
            return _userRepository.Get(branchId, userId);
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userName">User name</param>
        /// <returns>User model</returns>
        public UserModel? GetUserByUsername(string branchId, string userName)
        {
            return _userRepository.GetByUserName(branchId, userName);
        }

        /// <summary>
        /// Get operator user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? GetOperatorUser(string branchId, string userId)
        {
            var user = _userRepository.Get(branchId, userId);
            return user;
        }

        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>User model</returns>
        public bool TryLogin(string branchId, string userName, string password)
        {
            var model = _userRepository.GetByUserName(branchId, userName);
            if (model == null) return false;

            var result = (model.UserName == userName) && (model.Password == password);
            return result;
        }
    }
}
