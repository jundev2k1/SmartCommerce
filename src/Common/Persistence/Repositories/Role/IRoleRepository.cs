// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public interface IRoleRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<RoleModel> GetByCriteria(Expression<Func<Role, bool>> expression, int pageIndex, int pageSize);

		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Role model list</returns>
		RoleModel[] GetAll(string branchId);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchID">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Role model</returns>
		RoleModel? Get(string branchID, int roleId);

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
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, int roleId, Action<Role> UpdateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchID">Branch id</param>
		/// <param name="roleID">Role id</param>
		/// <returns>Delete status</returns>
		bool Delete(string branchID, int roleID);
	}
}
