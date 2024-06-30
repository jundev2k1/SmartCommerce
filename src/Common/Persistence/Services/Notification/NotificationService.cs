// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public sealed class NotificationService : ServiceBase, INotificationService
	{
		/// <summary>Context singleton</summary>
		private readonly INotificationRepository _notificationRepository;

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public NotificationService(INotificationRepository notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}
		#endregion

		#region Search
		/// <summary>
		/// Search
		/// </summary>
		/// <param name="searchParams">Search parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<NotificationModel> Search(NotificationSearchDto searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(searchParams.BranchId)) return new SearchResultModel<NotificationModel>();

			var condition = SearchConditionBuilder.NotificationSearch(searchParams);
			var result = _notificationRepository.Search(condition, pageIndex, pageSize);
			return result;
		}
		#endregion

		#region Queries
		/// <summary>
		/// Get mail template
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <returns>Notification model</returns>
		public NotificationModel? Get(string branchId, long id, string userId)
		{
			return _notificationRepository.Get(branchId, id, userId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Notification model</param>
		/// <returns>Update status</returns>
		public bool Insert(NotificationModel model)
		{
			return _notificationRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, long id, string userId, Action<Notification> updateAction)
		{
			return _notificationRepository.Update(branchId, id, userId, updateAction);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <returns>Update status</returns>
		public bool UpdateStatus(string branchId, long id, string userId)
		{
			var updateAction = (Notification mail) =>
			{
				mail.Status = mail.Status == NotificationStatusEnum.UnRead
					? NotificationStatusEnum.Read
					: NotificationStatusEnum.UnRead;
			};
			return _notificationRepository.Update(branchId, id, userId, updateAction);
		}
		#endregion
	}
}
