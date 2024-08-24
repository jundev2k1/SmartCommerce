// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public interface INotificationService
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="searchParams">Search parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<NotificationModel> GetByCriteria(NotificationFilterModel searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE);

		/// <summary>
		/// Get mail template
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Notification id</param>
		/// <param name="userId">User id</param>
		/// <returns>Notification model</returns>
		NotificationModel? Get(string branchId, long id, string userId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Notification model</param>
		/// <returns>Insert status</returns>
		bool Insert(NotificationModel model);

		bool Update(string branchId, long Id, string userId, Action<Notification> updateAction);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="Id">Notification id</param>
		/// <param name="userId">User id</param>
		/// <returns>Update status</returns>
		bool UpdateStatus(string branchId, long Id, string userId);
	}
}
