// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface IMailTemplateRepository
	{
		/// <summary>
		/// Search
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<MailTemplateModel>> Search(MailTemplateFilterModel input);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Mail template model</returns>
		Task<MailTemplateModel?> Get(string branchId, string userId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Mail template model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(MailTemplateModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Mail template model</param>
		/// <returns>Update status</returns>
		Task<bool> Update(MailTemplateModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">User id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, string mailId, Action<MailTemplate> updateAction);
	}
}
