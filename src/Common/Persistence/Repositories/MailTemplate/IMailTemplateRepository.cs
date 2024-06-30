// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public interface IMailTemplateRepository
	{
		/// <summary>
		/// Search
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<MailTemplateModel> Search(Expression<Func<MailTemplate, bool>> expression, int pageIndex, int pageSize);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">User id</param>
		/// <returns>Mail template model</returns>
		MailTemplateModel? Get(string branchId, string userId);

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
		/// <param name="mailId">User id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, string mailId, Action<MailTemplate> updateAction);
	}
}
