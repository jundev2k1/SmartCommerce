// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public interface IRoleService
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="searchParams">Search parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<RoleModel> GetByCriteria(RoleFilterModel searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE);

		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Role model list</returns>
		RoleModel[] GetAll(string branchId);

		/// <summary>
		/// Get role
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Role model</returns>
		RoleModel? Get(string branchId, int roleId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Insert status</returns>
		bool Insert(RoleModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Update status</returns>
		bool Update(RoleModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, int roleId, Action<Role> updateAction);

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Delete status</returns>
		bool TempDelete(string branchId, int roleId);
	}
}
