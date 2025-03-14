// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class MailTemplateRepository : RepositoryBase, IMailTemplateRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MailTemplateRepository(ApplicationDBContext dbContext, IFileLogger logger)
			: base(dbContext, logger)
		{
		}

		/// <summary>
		/// Search
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<MailTemplateModel>> Search(MailTemplateFilterModel input)
		{
			var searchCondition = FilterConditionBuilder.GetMailTemplateFilters(input);

			// Search with query
			var query = _dbContext.MailTemplates
				.AsQueryable()
				.Where(searchCondition);

			// Handle get page information
			var queryCount = await query.CountAsync();
			var isSurplus = (queryCount % input.PageSize) > 0;
			var totalPage = queryCount / input.PageSize + (isSurplus ? 1 : 0);

			// Handle get data with paging
			var data = await query
				.Skip(input.PageSkip)
				.Take(input.PageSize)
				.Select(mailTemplate => mailTemplate.MapToModel())
				.ToArrayAsync();

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
		public async Task<MailTemplateModel?> Get(string branchId, string mailId)
		{
			var mail = await _dbContext.MailTemplates
				.FirstOrDefaultAsync(user => (user.BranchId == branchId) && (user.MailId == mailId));
			return mail?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public async Task<bool> Insert(MailTemplateModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var mailTemplate = await _dbContext.MailTemplates
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.MailId == model.MailId));
				if (mailTemplate != null) throw new ExistInDBException();

				var insertModel = model.MapToEntity();
				await _dbContext.AddAsync(insertModel);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status update</returns>
		public async Task<bool> Update(MailTemplateModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var mailTemplate = await _dbContext.MailTemplates
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.MailId == model.MailId));
				if (mailTemplate == null) throw new NotExistInDBException();

				var updateModel = model.MapToEntity();
				updateModel.DateCreated = mailTemplate.DateCreated;

				_dbContext.Update(updateModel);
				await _dbContext.SaveChangesAsync();
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
		public async Task<bool> Update(string branchId, string userId, Action<MailTemplate> UpdateAction)
		{
			var result = await BeginTransaction(async () =>
			{
				var user = await _dbContext.MailTemplates
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.MailId == userId));
				if (user == null) throw new NotExistInDBException();

				UpdateAction(user);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}
	}
}
