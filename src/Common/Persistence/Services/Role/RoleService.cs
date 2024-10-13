// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public sealed class RoleService : ServiceBase, IRoleService
	{
		/// <summary>Context singleton</summary>
		private readonly IRoleRepository _roleRepository;

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public RoleService(IRoleRepository roleRepository)
		{
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
		public SearchResultModel<RoleModel> GetByCriteria(RoleFilterModel searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(searchParams.BranchId)) return new SearchResultModel<RoleModel>();

			var condition = FilterConditionBuilder.GetRoleFilters(searchParams);
			var result = _roleRepository.GetByCriteria(condition, pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Get all role
		/// </summary>
		/// <param name="branchId"></param>
		/// <returns>A collection of role</returns>
		public RoleModel[] GetAll(string branchId)
		{
			return _roleRepository.GetAll(branchId);
		}

		/// <summary>
		/// Get role
		/// </summary>
		/// <param name="branchId">Branch ID</param>
		/// <param name="roleId">Role ID</param>
		/// <returns>Role model</returns>
		public RoleModel? Get(string branchId, int roleId)
		{
			return _roleRepository.Get(branchId, roleId);
		}
		/// <summary>
		/// Get role async
		/// </summary>
		/// <param name="branchId">Branch ID</param>
		/// <param name="roleId">Role ID</param>
		/// <returns>Role model</returns>
		public async Task<RoleModel?> GetAsync(string branchId, int roleId)
		{
			return await _roleRepository.GetAsync(branchId, roleId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Inser status</returns>
		public bool Insert(RoleModel model)
		{
			return _roleRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Update status</returns>
		public bool Update(RoleModel model)
		{
			return _roleRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, int roleId, Action<Role> updateAction)
		{
			return _roleRepository.Update(branchId, roleId, updateAction);
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Update status</returns>
		public bool TempDelete(string branchId, int roleId)
		{
			var role = _roleRepository.Get(branchId, roleId);
			if (role == null) return false;

			role.Status = RoleStatusEnum.Active;
			return true;
		}

		#endregion
	}
}
