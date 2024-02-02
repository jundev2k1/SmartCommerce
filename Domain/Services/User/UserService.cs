using Domain.Entities;
using Domain.Mapping;
using Domain.Models;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        /// <summary>Context singleton</summary>
        private readonly DBContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public UserService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        public UserModel?[] GetAllUser()
        {
            return _dbContext.Users
                .Select(user => user.MapToUserModel())
                .ToArray();
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? GetUser(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            return user.MapToUserModel();
        }

        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>User model</returns>
        public UserModel? TryLogin(string userName, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(user =>
                (user.UserName == userName) && (user.Password == password));

            return user.MapToUserModel();
        }
    }
}
