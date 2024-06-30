// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public sealed class MemberRepository : RepositoryBase, IMemberRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MemberRepository(DBContext dbContext, IFileLogger logger) : base(dbContext, logger)
		{
		}

		/// <summary>
		/// Search
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<MemberModel> Search(Expression<Func<Member, bool>> expression, int pageIndex, int pageSize)
		{
			var query = _dbContext.Members
				.AsQueryable()
				.Where(expression);

			var queryCount = query.Count();
			var isSurplus = (queryCount % pageSize) > 0;
			var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

			var pageSkip = (pageIndex - 1) * pageSize;
			var data = query
				.Skip(pageSkip)
				.Take(pageSize)
				.Select(member => member.MapToModel())
				.ToArray();

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
		public MemberModel[] GetAll(string branchId, bool isDeleted)
		{
			var result = _dbContext.Members
				.Where(member =>
					(member.BranchId == branchId)
					&& (member.DelFlg == isDeleted))
				.Select(member => member.MapToModel())
				.ToArray();

			return result;
		}

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberIds">Member id list</param>
		/// <returns>Member model list</returns>
		public MemberModel[] Gets(string branchId, string[] memberIds)
		{
			var result = _dbContext.Members
				.Where(member => (member.BranchId == branchId) && memberIds.Contains(member.MemberId))
				.Select(member => member.MapToModel())
				.ToArray();

			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Member model</returns>
		public MemberModel? Get(string branchId, string memberId)
		{
			var result = _dbContext.Members.FirstOrDefault(member =>
				(member.BranchId == branchId)
				&& (member.MemberId == memberId));

			return result?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Status insert</returns>
		public bool Insert(MemberModel model)
		{
			var result = BeginTransaction(() =>
			{
				var member = _dbContext.Members.FirstOrDefault(item =>
					(item.BranchId == model.BranchId)
					&& (item.MemberId == model.MemberId));
				if (member != null) throw new ExistInDBException();

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
		public bool Update(MemberModel model)
		{
			var result = BeginTransaction(() =>
			{
				var member = _dbContext.Members.FirstOrDefault(item =>
					(item.BranchId == model.BranchId)
					&& (item.MemberId == model.MemberId));
				if (member == null) throw new NotExistInDBException();

				var updateModel = model.MapToEntity();
				_dbContext.Update(updateModel);
				_dbContext.SaveChanges();
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
		public bool Update(string branchId, string memberId, Action<Member> UpdateAction)
		{
			var result = BeginTransaction(() =>
			{
				var member = _dbContext.Members.FirstOrDefault(item =>
					(item.BranchId == branchId)
					&& (item.MemberId == memberId));
				if (member == null) throw new NotExistInDBException();

				UpdateAction(member);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Delete status</returns>
		public bool Delete(string branchId, string memberId)
		{
			var result = BeginTransaction(() =>
			{
				var member = _dbContext.Members.FirstOrDefault(item =>
					(item.BranchId == branchId)
					&& (item.MemberId == memberId));
				if (member == null) throw new NotExistInDBException();

				_dbContext.Remove(member);
				_dbContext.SaveChanges();
			});
			return result;
		}
	}
}
