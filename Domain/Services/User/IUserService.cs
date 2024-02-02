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
        /// Try login
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>User model</returns>
        public UserModel? TryLogin(string userName, string password);
    }
}
