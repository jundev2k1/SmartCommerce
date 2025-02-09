// Copyright (c) 2024 - Jun Dev. All rights reserved

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
		/// <param name="searchParams">Search parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<UserModel> GetByCriteria(UserFilterModel searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(searchParams.BranchId)) return new SearchResultModel<UserModel>();

			var condition = FilterConditionBuilder.GetUserFilters(searchParams);
			var result = _userRepository.GetByCriteria(condition, pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Get all user
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>User list</returns>
		public UserModel[] GetAll(string branchId, bool isDeleted = false)
		{
			return _userRepository.GetAll(branchId, isDeleted);
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userIds">User id list</param>
		/// <returns>User model list</returns>
		public UserModel[] Gets(string branchId, string[] userIds)
		{
			return _userRepository.Gets(branchId, userIds);
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>User model</returns>
		public UserModel? Get(string branchId, string userId)
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
		/// Try login
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userName">User name</param>
		/// <param name="password">Password</param>
		/// <returns>User model</returns>
		public OperatorModel? TryLogin(string branchId, string userName, string password)
		{
			var user = _userRepository.GetByUserName(branchId, userName);
			if ((user == null)
				|| (user.Password != password)
				|| (user.RoleId.HasValue == false))
			{
				return null;
			}

			var role = _roleRepository.Get(user.BranchId, user.RoleId.Value);
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
		public bool Insert(UserModel model)
		{
			return _userRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">User model</param>
		/// <returns>Update status</returns>
		public bool Update(UserModel model)
		{
			return _userRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, string userId, Action<User> updateAction)
		{
			return _userRepository.Update(branchId, userId, updateAction);
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Update status</returns>
		public bool TempDelete(string branchId, string userId)
		{
			var user = _userRepository.Get(branchId, userId);
			if (user == null) return false;

			user.DelFlg = true;
			return _userRepository.Update(user);
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Delete status</returns>
		public bool Delete(string branchId, string userId)
		{
			return _userRepository.Delete(branchId, userId);
		}
		#endregion
	}
}
