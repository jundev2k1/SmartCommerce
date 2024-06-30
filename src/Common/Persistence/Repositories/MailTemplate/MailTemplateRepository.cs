// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public sealed class MailTemplateRepository : RepositoryBase, IMailTemplateRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MailTemplateRepository(DBContext dbContext, IFileLogger logger) : base(dbContext, logger)
		{
		}

		/// <summary>
		/// Search
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<MailTemplateModel> Search(Expression<Func<MailTemplate, bool>> expression, int pageIndex, int pageSize)
		{
			var query = _dbContext.MailTemplates
				.AsQueryable()
				.Where(expression);

			var queryCount = query.Count();
			var isSurplus = (queryCount % pageSize) > 0;
			var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

			var pageSkip = (pageIndex - 1) * pageSize;
			var data = query
				.Skip(pageSkip)
				.Take(pageSize)
				.Select(mailTemplate => mailTemplate.MapToModel())
				.ToArray();

			var result = new SearchResultModel<MailTemplateModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="mailId">Mail id</param>
		/// <returns>Mail model</returns>
		public MailTemplateModel? Get(string branchId, string mailId)
		{
			var result = _dbContext.MailTemplates
				.FirstOrDefault(user => (user.BranchId == branchId) && (user.MailId == mailId));

			return result?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public bool Insert(MailTemplateModel model)
		{
			var result = BeginTransaction(() =>
			{
				var mailTemplate = _dbContext.MailTemplates.FirstOrDefault(item =>
					(item.BranchId == model.BranchId)
					&& (item.MailId == model.MailId));
				if (mailTemplate != null) throw new ExistInDBException();

				var insertModel = model.MapToEntity();
				_dbContext.Add(insertModel);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status update</returns>
		public bool Update(MailTemplateModel model)
		{
			var result = BeginTransaction(() =>
			{
				var mailTemplate = _dbContext.MailTemplates.FirstOrDefault(item =>
					(item.BranchId == model.BranchId)
					&& (item.MailId == model.MailId));
				if (mailTemplate == null) throw new NotExistInDBException();

				var updateModel = model.MapToEntity();
				updateModel.DateCreated = mailTemplate.DateCreated;
				_dbContext.Update(updateModel);
				_dbContext.SaveChanges();
			});
			return result;
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="userId">Mail id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, string userId, Action<MailTemplate> UpdateAction)
		{
			var result = BeginTransaction(() =>
			{
				var user = _dbContext.MailTemplates.FirstOrDefault(item =>
					(item.BranchId == branchId)
					&& (item.MailId == userId));
				if (user == null) throw new NotExistInDBException();

				UpdateAction(user);
				_dbContext.SaveChanges();
			});
			return result;
		}
	}
}
