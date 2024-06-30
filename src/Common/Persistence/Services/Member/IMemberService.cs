// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public interface IMemberService
	{
		/// <summary>
		/// Search
		/// </summary>
		/// <param name="searchParams">Search parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<MemberModel> Search(MemberSearchDto searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE);

		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="isDeleted">Delete flag of member</param>
		/// <returns>A collection of member</returns>
		/// <remarks>Use only when executing asynchronously</remarks>
		MemberModel[] GetAll(string branchId, bool isDeleted = false);

		/// <summary>
		/// Gets
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberIds">Member id list</param>
		/// <returns>Member model list</returns>
		MemberModel[] Gets(string branchId, string[] memberIds);

		/// <summary>
		/// Get member
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
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, string memberId, Action<Member> updateAction);

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <remarks>Update delete flag to "true"</remarks>
		/// <returns>Delete status</returns>
		bool TempDelete(string branchId, string memberId);

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Delete status</returns>
		bool Delete(string branchId, string memberId);
	}
}
