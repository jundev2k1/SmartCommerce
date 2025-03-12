// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface IRoleRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<RoleModel>> GetByCriteria(RoleFilterModel input);

		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Role model list</returns>
		Task<RoleModel[]> GetAll(string branchId);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchID">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Role model</returns>
		Task<RoleModel?> Get(string branchID, int roleId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(RoleModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Update status</returns>
		Task<bool> Update(RoleModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, int roleId, Action<Role> UpdateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchID">Branch id</param>
		/// <param name="roleID">Role id</param>
		/// <returns>Delete status</returns>
		Task<bool> Delete(string branchID, int roleID);
	}
}
