﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface IUserRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="condition">Search condition input</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<UserModel>> GetByCriteria(UserFilterModel condition);

		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="isDeleted">Delete flag of user</param>
		/// <returns>User model list</returns>
		Task<UserModel[]> GetAll(string branchId, bool isDeleted);

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userIds">User id list</param>
		/// <returns>User model list</returns>
		Task<UserModel[]> Gets(string branchId, string[] userIds);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>User model</returns>
		Task<UserModel?> Get(string branchId, string userId);

		/// <summary>
		/// Get by user name
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="username">Username</param>
		/// <returns>User model</returns>
		Task<UserModel?> GetByUserName(string branchId, string username);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">User model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(UserModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">User model</param>
		/// <returns>Update status</returns>
		Task<bool> Update(UserModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, string userId, Action<User> updateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Delete status</returns>
		Task<bool> Delete(string branchId, string userId);
	}
}
