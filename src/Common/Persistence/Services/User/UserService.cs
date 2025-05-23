﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public sealed class UserService : ServiceBase, IUserService
	{
		#region Constructor
		/// <summary>Context singleton</summary>
		private readonly IUserRepository _userRepository;
		private readonly IRoleRepository _roleRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
		{
			_userRepository = userRepository;
			_roleRepository = roleRepository;
		}
		#endregion

		#region Queries
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<UserModel>> GetByCriteria(UserFilterModel input)
		{
			if (string.IsNullOrEmpty(input.BranchId)) return new ();

			var result = await _userRepository.GetByCriteria(input);
			return result;
		}

		/// <summary>
		/// Get all user
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>User list</returns>
		public async Task<UserModel[]> GetAll(string branchId, bool isDeleted = false)
		{
			return await _userRepository.GetAll(branchId, isDeleted);
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userIds">User id list</param>
		/// <returns>User model list</returns>
		public async Task<UserModel[]> Gets(string branchId, string[] userIds)
		{
			return await _userRepository.Gets(branchId, userIds);
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>User model</returns>
		public async Task<UserModel?> Get(string branchId, string userId)
		{
			return await _userRepository.Get(branchId, userId);
		}

		/// <summary>
		/// Get user by username
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userName">User name</param>
		/// <returns>User model</returns>
		public async Task<UserModel?> GetUserByUsername(string branchId, string userName)
		{
			return await _userRepository.GetByUserName(branchId, userName);
		}

		/// <summary>
		/// Try login
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userName">User name</param>
		/// <param name="password">Password</param>
		/// <returns>User model</returns>
		public async Task<OperatorModel?> TryLogin(string branchId, string userName, string password)
		{
			var user = await _userRepository.GetByUserName(branchId, userName);
			if ((user == null)
				|| (user.Password != password)
				|| (user.RoleId.HasValue == false))
			{
				return null;
			}

			var role = await _roleRepository.Get(user.BranchId, user.RoleId.Value);
			if (role == null) return null;

			return AuthMapping.MapToOperatorModel(user, role);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">User model</param>
		/// <returns>Insert status</returns>
		public async Task<bool> Insert(UserModel model)
		{
			return await _userRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">User model</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(UserModel model)
		{
			return await _userRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string userId, Action<User> updateAction)
		{
			return await _userRepository.Update(branchId, userId, updateAction);
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Update status</returns>
		public async Task<bool> TempDelete(string branchId, string userId)
		{
			return await _userRepository.Update(branchId, userId, user =>
			{
				user.DelFlg = true;
			});
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Delete status</returns>
		public async Task<bool> Delete(string branchId, string userId)
		{
			return await _userRepository.Delete(branchId, userId);
		}
		#endregion
	}
}
