using Domain.Entities;
using Domain.Mapping;
using Domain.Models;
using Domain.Repositories.User;

namespace Domain.Services
{
    public class UserService : IUserService
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
        /// <returns></returns>
        public UserModel[] GetAllUser()
        {
            return _userRepository.GetAll();
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? GetUser(string userId)
        {
            return _userRepository.Get(userId);
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>User model</returns>
        public UserModel? GetUserByUsername(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }

        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>User model</returns>
        public bool TryLogin(string userName, string password)
        {
            var model = _userRepository.GetByUserName(userName);
            if (model == null) return false;

            var result = (model.UserName == userName) && (model.Password == password);
            return result;
        }
    }
}
