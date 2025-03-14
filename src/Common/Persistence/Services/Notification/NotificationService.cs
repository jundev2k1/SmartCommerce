// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
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

		#region Queries
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<NotificationModel>> GetByCriteria(NotificationFilterModel input)
		{
			if (string.IsNullOrEmpty(input.BranchId)) return new SearchResultModel<NotificationModel>();

			var result = await _notificationRepository.GetByCriteria(input);
			return result;
		}

		/// <summary>
		/// Get mail template
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <returns>Notification model</returns>
		public async Task<NotificationModel?> Get(string branchId, long id, string userId)
		{
			return await _notificationRepository.Get(branchId, id, userId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Notification model</param>
		/// <returns>Update status</returns>
		public async Task<bool> Insert(NotificationModel model)
		{
			return await _notificationRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(
			string branchId,
			long id,
			string userId,
			Action<Notification> updateAction)
		{
			return await _notificationRepository.Update(branchId, id, userId, updateAction);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="id">Id</param>
		/// <param name="userId">User id</param>
		/// <returns>Update status</returns>
		public async Task<bool> UpdateStatus(string branchId, long id, string userId)
		{
			var updateAction = (Notification mail) =>
			{
				mail.Status = mail.Status == NotificationStatusEnum.UnRead
					? NotificationStatusEnum.Read
					: NotificationStatusEnum.UnRead;
			};
			return await _notificationRepository.Update(branchId, id, userId, updateAction);
		}
		#endregion
	}
}
