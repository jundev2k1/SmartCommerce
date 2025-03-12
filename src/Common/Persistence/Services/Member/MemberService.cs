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
		/// <param name="input">Search condition input</param>
		/// <returns>Search result model</returns>
		public async Task<SearchResultModel<MemberModel>> GetByCriteria(MemberFilterModel input)
		{
			if (string.IsNullOrEmpty(input.BranchId)) return new SearchResultModel<MemberModel>();

			var result = await _memberRepository.GetByCriteria(input);
			return result;
		}

		/// <summary>
		/// Get all member
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>Member list</returns>
		/// <remarks>Use only when executing asynchronously</remarks>
		public async Task<MemberModel[]> GetAll(string branchId, bool isDeleted = false)
		{
			return await _memberRepository.GetAll(branchId, isDeleted);
		}

		/// <summary>
		/// Get members
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberIds">Member id list</param>
		/// <returns>Member model list</returns>
		public async Task<MemberModel[]> Gets(string branchId, string[] memberIds)
		{
			return await _memberRepository.Gets(branchId, memberIds);
		}

		/// <summary>
		/// Get member
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Member model</returns>
		public async Task<MemberModel?> Get(string branchId, string memberId)
		{
			return await _memberRepository.Get(branchId, memberId);
		}
		#endregion

		#region Command
		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Member model</param>
		/// <returns>Insert status</returns>
		public async Task<bool> Insert(MemberModel model)
		{
			return await _memberRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Member model</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(MemberModel model)
		{
			return await _memberRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string memberId, Action<Member> updateAction)
		{
			return await _memberRepository.Update(branchId, memberId, updateAction);
		}

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Update status</returns>
		public async Task<bool> TempDelete(string branchId, string memberId)
		{
			var updateAction = (Member member) =>
			{
				member.DelFlg = true;
			};
			return await _memberRepository.Update(branchId, memberId, updateAction);
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <returns>Delete status</returns>
		public async Task<bool> Delete(string branchId, string memberId)
		{
			return await _memberRepository.Delete(branchId, memberId);
		}
		#endregion
	}
}
