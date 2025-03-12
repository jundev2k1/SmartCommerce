// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
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
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<RoleModel>> GetByCriteria(RoleFilterModel input)
		{
			if (string.IsNullOrEmpty(input.BranchId)) return new SearchResultModel<RoleModel>();

			var result = await _roleRepository.GetByCriteria(input);
			return result;
		}

		/// <summary>
		/// Get all role
		/// </summary>
		/// <param name="branchId"></param>
		/// <returns>A collection of role</returns>
		public async Task<RoleModel[]> GetAll(string branchId)
		{
			return await _roleRepository.GetAll(branchId);
		}

		/// <summary>
		/// Get role
		/// </summary>
		/// <param name="branchId">Branch ID</param>
		/// <param name="roleId">Role ID</param>
		/// <returns>Role model</returns>
		public async Task<RoleModel?> Get(string branchId, int roleId)
		{
			return await _roleRepository.Get(branchId, roleId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Inser status</returns>
		public async Task<bool> Insert(RoleModel model)
		{
			return await _roleRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(RoleModel model)
		{
			return await _roleRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, int roleId, Action<Role> updateAction)
		{
			return await _roleRepository.Update(branchId, roleId, updateAction);
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Update status</returns>
		public async Task<bool> TempDelete(string branchId, int roleId)
		{
			return await _roleRepository.Update(branchId, roleId, item =>
			{
				item.Status = RoleStatusEnum.Active;
			});
		}

		#endregion
	}
}
