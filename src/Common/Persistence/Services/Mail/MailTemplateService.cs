// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
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

		#region Queries
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<MailTemplateModel>> GetByCriteria(MailTemplateFilterModel input)
		{
			if (string.IsNullOrEmpty(input.BranchId)) return new SearchResultModel<MailTemplateModel>();

			var result = await _mailTemplateRepository.Search(input);
			return result;
		}

		/// <summary>
		/// Get mail template
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <returns>Mail template model</returns>
		public async Task<MailTemplateModel?> Get(string branchId, string mailId)
		{
			return await _mailTemplateRepository.Get(branchId, mailId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Mail template model</param>
		/// <returns>Update status</returns>
		public async Task<bool> Insert(MailTemplateModel model)
		{
			return await _mailTemplateRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Mail template model</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(MailTemplateModel model)
		{
			return await _mailTemplateRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string mailId, Action<MailTemplate> updateAction)
		{
			return await _mailTemplateRepository.Update(branchId, mailId, updateAction);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <returns>Update status</returns>
		public async Task<bool> UpdateStatus(string branchId, string mailId)
		{
			var updateAction = (MailTemplate mail) =>
			{
				mail.Status = mail.Status == MailTemplateStatusEnum.Active
					? MailTemplateStatusEnum.Inactive
					: MailTemplateStatusEnum.Active;
				mail.DateChanged = DateTime.Now;
			};
			return await _mailTemplateRepository.Update(branchId, mailId, updateAction);
		}
		#endregion
	}
}
