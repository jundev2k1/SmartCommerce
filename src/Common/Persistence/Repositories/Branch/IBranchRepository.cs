// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public interface IBranchRepository
	{
		/// <summary>
		/// Get all
		/// </summary>
		/// <returns>Branch model list</returns>
		BranchModel[] GetAll();

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Branch model</returns>
		BranchModel? Get(string branchId);
	}
}
