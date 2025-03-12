// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class MemberRepository : RepositoryBase, IMemberRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MemberRepository(ApplicationDBContext dbContext, IFileLogger logger)
			: base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<MemberModel>> GetByCriteria(MemberFilterModel input)
		{
			var searchCondition = FilterConditionBuilder.GetMemberFilters(input);

			// Search with query
			var query = _dbContext.Members
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
				.Select(member => member.MapToModel())
				.ToArrayAsync();

			var result = new SearchResultModel<MemberModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};
			return result;
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="isDeleted">Delete flag of member</param>
		/// <returns>A collection of member</returns>
		public async Task<MemberModel[]> GetAll(string branchId, bool isDeleted)
		{
			var result = await _dbContext.Members
				.Where(member => (member.BranchId == branchId)
					&& (member.DelFlg == isDeleted))
				.Select(member => member.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberIds">Member id list</param>
		/// <returns>Member model list</returns>
		public async Task<MemberModel[]> Gets(string branchId, string[] memberIds)
		{
			var result = await _dbContext.Members
				.Where(member => (member.BranchId == branchId) && memberIds.Contains(member.MemberId))
				.Select(member => member.MapToModel())
				.ToArrayAsync();
			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Member model</returns>
		public async Task<MemberModel?> Get(string branchId, string memberId)
		{
			var member = await _dbContext.Members
				.FirstOrDefaultAsync(member =>
					(member.BranchId == branchId)
					&& (member.MemberId == memberId));
			return member?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public async Task<bool> Insert(MemberModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var member = await _dbContext.Members
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.MemberId == model.MemberId));
				if (member != null) throw new ExistInDBException();

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
		public async Task<bool> Update(MemberModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var member = await _dbContext.Members
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.MemberId == model.MemberId));
				if (member == null) throw new NotExistInDBException();

				var updateModel = model.MapToEntity();
				_dbContext.Update(updateModel);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string memberId, Action<Member> UpdateAction)
		{
			var result = await BeginTransaction(async () =>
			{
				var member = await _dbContext.Members
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.MemberId == memberId));
				if (member == null) throw new NotExistInDBException();

				UpdateAction(member);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Delete status</returns>
		public async Task<bool> Delete(string branchId, string memberId)
		{
			var result = await BeginTransaction(async () =>
			{
				var member = await _dbContext.Members
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.MemberId == memberId));
				if (member == null) throw new NotExistInDBException();

				_dbContext.Remove(member);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}
	}
}
