// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
	public interface IMemberRepository
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<MemberModel> GetByCriteria(Expression<Func<Member, bool>> expression, int pageIndex, int pageSize);

		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="isDeleted">Delete flag of member</param>
		/// <returns>Member model list</returns>
		MemberModel[] GetAll(string branchId, bool isDeleted);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberIds">Member id list</param>
		/// <returns>Member model list</returns>
		MemberModel[] Gets(string branchId, string[] memberIds);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Member model</returns>
		MemberModel? Get(string branchId, string memberId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Member model</param>
		/// <returns>Insert status</returns>
		bool Insert(MemberModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Member model</param>
		/// <returns>Update status</returns>
		bool Update(MemberModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, string memberId, Action<Member> UpdateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Delete status</returns>
		bool Delete(string branchId, string memberId);
	}
}
