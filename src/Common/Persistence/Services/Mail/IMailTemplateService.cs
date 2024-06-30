// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public interface IMailTemplateService
	{
		/// <summary>
		/// Search
		/// </summary>
		/// <param name="searchParams">Search parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<MailTemplateModel> Search(MailTemplateSearchDto searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE);

		/// <summary>
		/// Get mail template
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">MailTemplate id</param>
		/// <returns>MailTemplate model</returns>
		MailTemplateModel? Get(string branchId, string mailId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Mail template model</param>
		/// <returns>Insert status</returns>
		bool Insert(MailTemplateModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Mail template model</param>
		/// <returns>Update status</returns>
		bool Update(MailTemplateModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, string mailId, Action<MailTemplate> updateAction);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <returns>Update status</returns>
		bool UpdateStatus(string branchId, string mailId);
	}
}
