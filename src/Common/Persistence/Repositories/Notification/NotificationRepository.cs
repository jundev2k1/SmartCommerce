// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class NotificationRepository : RepositoryBase, INotificationRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public NotificationRepository(ApplicationDBContext dbContext, IFileLogger logger)
			: base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<NotificationModel>> GetByCriteria(NotificationFilterModel input)
		{
			var searchCondition = FilterConditionBuilder.GetNotificationFilters(input);

			// Search with query
			var query = _dbContext.Notifications
				.AsQueryable()
				.Where(searchCondition);

			// Handle get page information
			var queryCount = await query.CountAsync();
			var isSurplus = (queryCount % input.PageSize) > 0;
			var totalPage = queryCount / input.PageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var data = await query
				.Skip(input.PageSkip)
				.Take(input.PageSize)
				.Select(mailTemplate => mailTemplate.MapToModel())
				.ToArrayAsync();

			var result = new SearchResultModel<NotificationModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <returns>Notification model</returns>
		public async Task<NotificationModel?> Get(string branchId, long id, string userId)
		{
			var notification = await _dbContext.Notifications
				.FirstOrDefaultAsync(item =>
					(item.BranchId == branchId)
					&& (item.Id == id)
					&& (item.UserId == userId));
			return notification?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public async Task<bool> Insert(NotificationModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var notification = await _dbContext.Notifications
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.Id == model.Id)
						&& (item.UserId == model.UserId));
				if (notification != null) throw new ExistInDBException();

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
		public async Task<bool> Update(NotificationModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var notification = await _dbContext.Notifications
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.Id == model.Id)
						&& (item.UserId == model.UserId));
				if (notification == null) throw new NotExistInDBException();

				var updateModel = notification.MapToEntity(model);
				updateModel.DateCreated = notification.DateCreated;
				_dbContext.Update(updateModel);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Notification id</param>
		/// <param name="userId">User Id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, long id, string userId, Action<Notification> UpdateAction)
		{
			var result = await BeginTransaction(async () =>
			{
				var notification = await _dbContext.Notifications
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.Id == id)
						&& (item.UserId == userId));
				if (notification == null) throw new NotExistInDBException();

				UpdateAction(notification);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}
	}
}
