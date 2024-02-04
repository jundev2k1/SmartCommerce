using Domain.Entities;
using Domain.Mapping;
using Domain.Models;

namespace Domain.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private DBContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchParams">Search parameters</param>
        /// <returns>A collection of user following search parameters</returns>
        public UserModel[] Search(Dictionary<string, string> searchParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>A collection of user</returns>
        public UserModel[] GetAll(string branchId)
        {
            var result = _dbContext.Users
                .Where(user => user.BranchID == branchId)
                .Select(user => user.MapToUserModel())
                .ToArray();

            return result;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? Get(string branchId, string userId)
        {
            var result = _dbContext.Users
                .FirstOrDefault(user => (user.BranchID == branchId) && (user.UserId == userId));
            return result?.MapToUserModel();
        }

        /// <summary>
        /// Get by user name
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="username">User name</param>
        /// <returns>User model</returns>
        public UserModel? GetByUserName(string branchId, string username)
        {
            var result = _dbContext.Users
                .FirstOrDefault(user => (user.BranchID == branchId) && (user.UserName == username));
            return result?.MapToUserModel();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Status insert</returns>
        public bool Insert(UserModel model)
        {
            var user = Get(model.BranchID, model.UserId);
            if (user != null) return false;

            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Status update</returns>
        public bool Update(UserModel model)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            var userUpdate = _dbContext.Users
                .FirstOrDefault(user => (user.UserId == model.BranchID) && (user.UserId == model.UserId));
            if (userUpdate == null) return false;

            userUpdate.UserName = model.UserName;
            userUpdate.Password = model.Password;
            userUpdate.PhoneNumber = model.PhoneNumber;
            userUpdate.FirstName = model.FirstName;
            userUpdate.LastName = model.LastName;
            userUpdate.Avatar = model.Avatar;
            userUpdate.Address1 = model.Address1;
            userUpdate.Address2 = model.Address2;
            userUpdate.Address3 = model.Address3;
            userUpdate.Address4 = model.Address4;
            userUpdate.Birthday = model.Birthday;
            userUpdate.UserName = model.UserName;
            userUpdate.Password = model.Password;
            userUpdate.Status = model.Status;
            userUpdate.DateChanged = DateTime.Now;
            userUpdate.Email = model.Email;
            userUpdate.LastChanged = model.LastChanged;
            userUpdate.RoleID = model.RoleID;
            userUpdate.Sex = model.Sex;

            try
            {
                _dbContext.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string userId)
        {
            var user = Get(branchId, userId);
            if (user == null) return false;

            try
            {
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
