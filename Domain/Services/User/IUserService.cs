using Domain.Models;

namespace Domain.Services
{
    public interface IUserService : IServiceBase
    {
        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns>A collection of users</returns>
        public UserModel?[] GetAllUser();

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? GetUser(string userId);

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="userName">Username (login id)</param>
        /// <returns>User model</returns>
        public UserModel? GetUserByUsername(string userName);

        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>User model</returns>
        public bool TryLogin(string userName, string password);
    }
}
