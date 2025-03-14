// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public interface INotificationService
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<NotificationModel>> GetByCriteria(NotificationFilterModel input);

		/// <summary>
		/// Get mail template
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Notification id</param>
		/// <param name="userId">User id</param>
		/// <returns>Notification model</returns>
		Task<NotificationModel?> Get(string branchId, long id, string userId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Notification model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(NotificationModel model);

		Task<bool> Update(string branchId, long Id, string userId, Action<Notification> updateAction);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="Id">Notification id</param>
		/// <param name="userId">User id</param>
		/// <returns>Update status</returns>
		Task<bool> UpdateStatus(string branchId, long Id, string userId);
	}
}
