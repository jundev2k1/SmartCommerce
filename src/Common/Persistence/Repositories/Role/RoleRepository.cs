// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class RoleRepository : RepositoryBase, IRoleRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public RoleRepository(ApplicationDBContext dbContext, IFileLogger logger)
			: base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<RoleModel>> GetByCriteria(RoleFilterModel input)
		{
			var searchCondition = FilterConditionBuilder.GetRoleFilters(input);

			// Search with query
			var query = _dbContext.Roles
				.AsQueryable()
				.Where(searchCondition)
				.OrderBy(role => role.Priority)
				.ThenByDescending(role => role.DateCreated);

			// Handle get page information
			var queryCount = await query.CountAsync();
			var isSurplus = (queryCount % input.PageSize) > 0;
			var totalPage = queryCount / input.PageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var data = await query
				.Skip(input.PageSkip)
				.Take(input.PageSize)
				.Select(role => role.MapToModel())
				.ToArrayAsync();

			var result = new SearchResultModel<RoleModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};
			return result;
		}

		/// <summary>
		/// Get all role
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>A collection of role</returns>
		public async Task<RoleModel[]> GetAll(string branchId)
		{
			var result = await _dbContext.Roles
				.Where(role => (role.BranchId == branchId)
					&& (role.Status == RoleStatusEnum.Active))
				.Select(role => role.MapToModel())
				.ToArrayAsync();

			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Role model</returns>
		public async Task<RoleModel?> Get(string branchId, int roleId)
		{
			var data = await _dbContext.Roles
				.FirstOrDefaultAsync(role =>
					(role.BranchId == branchId)
					&& (role.RoleId == roleId));
			return data?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Status insert</returns>
		public async Task<bool> Insert(RoleModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var role = await _dbContext.Roles
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.RoleId == model.RoleId));
				if (role != null) throw new ExistInDBException();

				var insertModel = model.MapToEntity();
				await _dbContext.AddAsync(insertModel);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Status update</returns>
		public Task<bool> Update(RoleModel model)
		{
			var result = BeginTransaction(async () =>
			{
				var role = await _dbContext.Roles
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.RoleId == model.RoleId));
				if (role == null) throw new NotExistInDBException();

				var updateModel = model.MapToEntity();
				_dbContext.Update(updateModel);
				await _dbContext.SaveChangesAsync();
			});

			return result;
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, int roleId, Action<Role> UpdateAction)
		{
			var result = await BeginTransaction(async () =>
			{
				var role = await _dbContext.Roles
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.RoleId == roleId));
				if (role == null) throw new NotExistInDBException();

				UpdateAction(role);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Delete status</returns>
		public async Task<bool> Delete(string branchId, int roleId)
		{
			var result = await BeginTransaction(async () =>
			{
				var role = await _dbContext.Roles
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.RoleId == roleId));
				if (role == null) throw new NotExistInDBException();

				_dbContext.Remove(role);
				await _dbContext.SaveChangesAsync();
			});

			return result;
		}
	}
}
