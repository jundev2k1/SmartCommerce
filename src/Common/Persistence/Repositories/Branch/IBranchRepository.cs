// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface IBranchRepository
	{
		/// <summary>
		/// Get all
		/// </summary>
		/// <returns>Branch model list</returns>
		Task<BranchModel[]> GetAll();

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Branch model</returns>
		Task<BranchModel?> Get(string branchId);
	}
}
