// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public interface IBranchService
	{
		/// <summary>
		/// Get all branch
		/// </summary>
		/// <returns>A collection of branch</returns>
		Task<BranchModel?[]> GetAll();

		/// <summary>
		/// Get user
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Branch model</returns>
		Task<BranchModel?> Get(string branchId);
	}
}
