// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public sealed class MailTemplateService : ServiceBase, IMailTemplateService
	{
		#region Constructor
		/// <summary>Context singleton</summary>
		private readonly IMailTemplateRepository _mailTemplateRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public MailTemplateService(IMailTemplateRepository mailTemplateRepository)
		{
			_mailTemplateRepository = mailTemplateRepository;
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
		public SearchResultModel<MailTemplateModel> Search(MailTemplateSearchDto searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(searchParams.BranchId)) return new SearchResultModel<MailTemplateModel>();

			var condition = SearchConditionBuilder.MailTemplateSearch(searchParams);
			var result = _mailTemplateRepository.Search(condition, pageIndex, pageSize);
			return result;
		}
		#endregion

		#region Queries
		/// <summary>
		/// Get mail template
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <returns>Mail template model</returns>
		public MailTemplateModel? Get(string branchId, string mailId)
		{
			return _mailTemplateRepository.Get(branchId, mailId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Mail template model</param>
		/// <returns>Update status</returns>
		public bool Insert(MailTemplateModel model)
		{
			return _mailTemplateRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Mail template model</param>
		/// <returns>Update status</returns>
		public bool Update(MailTemplateModel model)
		{
			return _mailTemplateRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, string mailId, Action<MailTemplate> updateAction)
		{
			return _mailTemplateRepository.Update(branchId, mailId, updateAction);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <returns>Update status</returns>
		public bool UpdateStatus(string branchId, string mailId)
		{
			var updateAction = (MailTemplate mail) =>
			{
				mail.Status = mail.Status == MailTemplateStatusEnum.Active
					? MailTemplateStatusEnum.Inactive
					: MailTemplateStatusEnum.Active;
				mail.DateChanged = DateTime.Now;
			};
			return _mailTemplateRepository.Update(branchId, mailId, updateAction);
		}
		#endregion
	}
}
