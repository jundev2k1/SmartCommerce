// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class UserRepository : RepositoryBase, IUserRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public UserRepository(ApplicationDBContext dbContext, IFileLogger logger)
			: base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<UserModel>> GetByCriteria(UserFilterModel input)
		{
			var searchCondition = FilterConditionBuilder.GetUserFilters(input);

			// Search with query
			var query = _dbContext.Users
				.AsQueryable()
				.Where(searchCondition)
				.OrderByDynamic(input);

			// Handle get page information
			var queryCount = await query.CountAsync();
			var isSurplus = (queryCount % input.PageSize) > 0;
			var totalPage = queryCount / input.PageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var data = await query
				.Skip(input.PageSkip)
				.Take(input.PageSize)
				.Select(user => user.MapToModel())
				.ToArrayAsync();

			var result = new SearchResultModel<UserModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};
			return result;
		}

		/// <summary>
		/// Get all user
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="isDeleted">Delete flag of user</param>
		/// <returns>A collection of user</returns>
		public async Task<UserModel[]> GetAll(string branchId, bool isDeleted)
		{
			var result = await _dbContext.Users
				.Where(user => (user.BranchId == branchId)
					&& (user.DelFlg == isDeleted))
				.Select(user => user.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userIds">User id list</param>
		/// <returns>User model list</returns>
		public async Task<UserModel[]> Gets(string branchId, string[] userIds)
		{
			var result = await _dbContext.Users
				.Where(user => (user.BranchId == branchId) && userIds.Contains(user.UserId))
				.Select(user => user.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>User model</returns>
		public async Task<UserModel?> Get(string branchId, string userId)
		{
			var user = await _dbContext.Users
				.FirstOrDefaultAsync(user =>
					(user.BranchId == branchId)
					&& (user.UserId == userId));
			return user?.MapToModel();
		}

		/// <summary>
		/// Get by user name
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="username">User name</param>
		/// <returns>User model</returns>
		public async Task<UserModel?> GetByUserName(string branchId, string username)
		{
			var user = await _dbContext.Users
				.FirstOrDefaultAsync(user =>
					(user.BranchId == branchId)
					&& (user.UserName == username)
					&& (user.DelFlg == false));
			return user?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public async Task<bool> Insert(UserModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var user = await _dbContext.Users
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.UserId == model.UserId));
				if (user != null) throw new ExistInDBException();

				var insertModel = model.MapToEntity();
				await _dbContext.AddAsync(insertModel);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status update</returns>
		public async Task<bool> Update(UserModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var user = await _dbContext.Users
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.UserId == model.UserId));
				if (user == null) throw new NotExistInDBException();

				var updateModel = model.MapToEntity();
				updateModel.DateChanged = DateTime.Now;
				_dbContext.Update(updateModel);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string userId, Action<User> UpdateAction)
		{
			var result = await BeginTransaction(async () =>
			{
				var user = await _dbContext.Users
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.UserId == userId));
				if (user == null) throw new NotExistInDBException();

				UpdateAction(user);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Delete status</returns>
		public async Task<bool> Delete(string branchId, string userId)
		{
			var result = await BeginTransaction(async () =>
			{
				var user = await _dbContext.Users
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.UserId == userId));
				if (user == null) throw new NotExistInDBException();

				_dbContext.Remove(user);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}
	}
}
