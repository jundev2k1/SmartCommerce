using Domain.Models;

namespace Domain.Repositories.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchParams">Search parameters</param>
        /// <returns>User model list</returns>
        public UserModel[] Search(Dictionary<string, string> searchParams);

        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>User model list</returns>
        public UserModel[] GetAll(string branchId);

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? Get(string branchId, string userId);

        /// <summary>
        /// Get by user name
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="username">Username</param>
        /// <returns>User model</returns>
        public UserModel? GetByUserName(string branchId, string username);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>Insert status</returns>
        public bool Insert(UserModel model);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>Update status</returns>
        public bool Update(UserModel model);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string userId);
    }
}
