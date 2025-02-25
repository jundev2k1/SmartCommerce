// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public interface IUserService
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="condition">Search condition</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<UserModel>> GetByCriteria(UserFilterModel condition);

		/// <summary>
		/// Get all user
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="isDeleted">Delete flag of user</param>
		/// <returns>A collection of users</returns>
		UserModel[] GetAll(string branchId, bool isDeleted = false);

		/// <summary>
		/// Get user
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userIds">User id list</param>
		/// <returns>User model list</returns>
		UserModel[] Gets(string branchId, string[] userIds);

		/// <summary>
		/// Get user
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>User model</returns>
		UserModel? Get(string branchId, string userId);

		/// <summary>
		/// Get user
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userName">Username (login id)</param>
		/// <returns>User model</returns>
		UserModel? GetUserByUsername(string branchId, string userName);

		/// <summary>
		/// Try login
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userName">User name</param>
		/// <param name="password">Password</param>
		/// <returns>Operator model</returns>
		OperatorModel? TryLogin(string branchId, string userName, string password);

		/// <summary>
		/// Insert user
		/// </summary>
		/// <param name="model">User model</param>
		/// <returns>Insert status</returns>
		bool Insert(UserModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">User model</param>
		/// <returns>Update status</returns>
		bool Update(UserModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, string userId, Action<User> UpdateAction);

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <remarks>Update delete flag to "true"</remarks>
		/// <returns>Delete status</returns>
		bool TempDelete(string branchId, string userId);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Delete status</returns>
		bool Delete(string branchId, string userId);
	}
}
