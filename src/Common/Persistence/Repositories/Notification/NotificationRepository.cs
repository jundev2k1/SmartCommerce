// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public sealed class NotificationRepository : RepositoryBase, INotificationRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public NotificationRepository(DBContext dbContext, IFileLogger logger) : base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<NotificationModel> GetByCriteria(Expression<Func<Notification, bool>> expression, int pageIndex, int pageSize)
		{
			var query = _dbContext.Notifications
				.AsQueryable()
				.Where(expression);

			var queryCount = query.Count();
			var isSurplus = (queryCount % pageSize) > 0;
			var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

			var pageSkip = (pageIndex - 1) * pageSize;
			var data = query
				.Skip(pageSkip)
				.Take(pageSize)
				.Select(mailTemplate => mailTemplate.MapToModel())
				.ToArray();

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
		public NotificationModel? Get(string branchId, long id, string userId)
		{
			var result = _dbContext.Notifications.FirstOrDefault(item =>
				(item.BranchId == branchId)
				&& (item.Id == id)
				&& (item.UserId == userId));

			return result?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public bool Insert(NotificationModel model)
		{
			var result = BeginTransaction(() =>
			{
				var notification = _dbContext.Notifications.FirstOrDefault(item =>
					(item.BranchId == model.BranchId)
					&& (item.Id == model.Id)
					&& (item.UserId == model.UserId));
				if (notification != null) throw new ExistInDBException();

				var insertModel = model.MapToEntity();
				_dbContext.Add(insertModel);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status update</returns>
		public bool Update(NotificationModel model)
		{
			var result = BeginTransaction(() =>
			{
				var notification = _dbContext.Notifications.FirstOrDefault(item =>
					(item.BranchId == model.BranchId)
					&& (item.Id == model.Id)
					&& (item.UserId == model.UserId));
				if (notification == null) throw new NotExistInDBException();

				var updateModel = notification.MapToEntity(model);
				updateModel.DateCreated = notification.DateCreated;
				_dbContext.Update(updateModel);
				_dbContext.SaveChanges();
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
		public bool Update(string branchId, long id, string userId, Action<Notification> UpdateAction)
		{
			var result = BeginTransaction(() =>
			{
				var notification = _dbContext.Notifications.FirstOrDefault(item =>
					(item.BranchId == branchId)
					&& (item.Id == id)
					&& (item.UserId == userId));
				if (notification == null) throw new NotExistInDBException();

				UpdateAction(notification);
				_dbContext.SaveChanges();
			});
			return result;
		}
	}
}
