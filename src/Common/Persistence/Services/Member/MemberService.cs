// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public sealed class MemberService : ServiceBase, IMemberService
	{
		/// <summary>Context singleton</summary>
		private readonly IMemberRepository _memberRepository;

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public MemberService(IMemberRepository memberRepository)
		{
			_memberRepository = memberRepository;
		}
		#endregion

		#region Queries
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="searchParams">Search parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<MemberModel> GetByCriteria(MemberFilterModel searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			if (string.IsNullOrEmpty(searchParams.BranchId)) return new SearchResultModel<MemberModel>();

			var condition = FilterConditionBuilder.GetMemberFilters(searchParams);
			var result = _memberRepository.GetByCriteria(condition, pageIndex, pageSize);
			return result;
		}

		/// <summary>
		/// Get all member
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Member list</returns>
		/// <remarks>Use only when executing asynchronously</remarks>
		public MemberModel[] GetAll(string branchId, bool isDeleted = false)
		{
			return _memberRepository.GetAll(branchId, isDeleted);
		}

		/// <summary>
		/// Get members
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberIds">Member id list</param>
		/// <returns>Member model list</returns>
		public MemberModel[] Gets(string branchId, string[] memberIds)
		{
			return _memberRepository.Gets(branchId, memberIds);
		}

		/// <summary>
		/// Get member
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Member model</returns>
		public MemberModel? Get(string branchId, string memberId)
		{
			return _memberRepository.Get(branchId, memberId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Member model</param>
		/// <returns>Insert status</returns>
		public bool Insert(MemberModel model)
		{
			return _memberRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Member model</param>
		/// <returns>Update status</returns>
		public bool Update(MemberModel model)
		{
			return _memberRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, string memberId, Action<Member> updateAction)
		{
			return _memberRepository.Update(branchId, memberId, updateAction);
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Update status</returns>
		public bool TempDelete(string branchId, string memberId)
		{
			var updateAction = (Member member) =>
			{
				member.DelFlg = true;
			};
			return _memberRepository.Update(branchId, memberId, updateAction);
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Delete status</returns>
		public bool Delete(string branchId, string memberId)
		{
			return _memberRepository.Delete(branchId, memberId);
		}
		#endregion
	}
}
