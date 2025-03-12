// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class BranchRepository : RepositoryBase, IBranchRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public BranchRepository(ApplicationDBContext dbContext, IFileLogger logger) : base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <returns>A collection of branch</returns>
		public async Task<BranchModel[]> GetAll()
		{
			var result = await _dbContext.Branches
				.Where(branch => branch.Status == BranchStatusEnum.Active)
				.Select(branch => branch.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Branch model</returns>
		public async Task<BranchModel?> Get(string branchId)
		{
			var result = await _dbContext.Branches
				.FirstOrDefaultAsync(branch => branch.BranchId == branchId);
			return result?.MapToModel();
		}
	}
}
