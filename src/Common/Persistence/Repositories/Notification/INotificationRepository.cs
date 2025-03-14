// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface INotificationRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<NotificationModel>> GetByCriteria(NotificationFilterModel input);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <returns>Notification model</returns>
		Task<NotificationModel?> Get(string branchId, long id, string userId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Notification model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(NotificationModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, long id, string userId, Action<Notification> updateAction);
	}
}
