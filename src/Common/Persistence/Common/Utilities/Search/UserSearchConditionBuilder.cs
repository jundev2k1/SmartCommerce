#pragma warning disable CS0618

using ErpManager.Common.Utilities;

namespace ErpManager.Persistence.Common.Utilities.Search
{
    public partial class SearchConditionBuilder
    {
        public static Expression<Func<User, bool>> UserSearch(UserSearchDto searchDto)
        {
            var predicate = PredicateBuilder.True<User>();

            if (string.IsNullOrEmpty(searchDto.BranchId) == false)
            {
                predicate.And(u => u.BranchId.Contains(searchDto.BranchId));
            }

            if (string.IsNullOrEmpty(searchDto.UserId) == false)
            {
                predicate.And(u => u.UserId.StartsWith(searchDto.UserId));
            }

            if (string.IsNullOrEmpty(searchDto.UserName) == false)
            {
                predicate.And(u => u.UserName.StartsWith(searchDto.UserName));
            }

            if (string.IsNullOrEmpty(searchDto.FirstName) == false)
            {
                predicate.And(u => u.FirstName.Contains(searchDto.FirstName));
            }

            if (string.IsNullOrEmpty(searchDto.LastName) == false)
            {
                predicate.And(u => u.LastName.Contains(searchDto.LastName));
            }

            if (string.IsNullOrEmpty(searchDto.Email) == false)
            {
                predicate.And(u => u.Email.StartsWith(searchDto.Email));
            }

            if (string.IsNullOrEmpty(searchDto.PhoneNumber) == false)
            {
                predicate.And(u => u.PhoneNumber.Contains(searchDto.PhoneNumber));
            }

            if (string.IsNullOrEmpty(searchDto.Address1) == false)
            {
                predicate.And(u => u.Address1.Contains(searchDto.Address1));
            }

            if (string.IsNullOrEmpty(searchDto.Address2) == false)
            {
                predicate.And(u => u.Address2.Contains(searchDto.Address2));
            }

            if (string.IsNullOrEmpty(searchDto.Address3) == false)
            {
                predicate.And(u => u.Address3.Contains(searchDto.Address3));
            }

            if (string.IsNullOrEmpty(searchDto.Address4) == false)
            {
                predicate.And(u => u.Address4.Contains(searchDto.Address4));
            }

            if (string.IsNullOrEmpty(searchDto.CreatedBy) == false)
            {
                predicate.And(u => u.CreatedBy.Equals(searchDto.CreatedBy));
            }

            if (searchDto.MinAge > 0) predicate.And(u => searchDto.MinAge <= CommonUtility.CalculateTime(u.Birthday).Years);
            if (searchDto.MaxAge > 0) predicate.And(u => searchDto.MaxAge >= CommonUtility.CalculateTime(u.Birthday).Years);

            predicate.And(u => u.Status.Equals(searchDto.Status));
            predicate.And(u => u.DelFlg.Equals(searchDto.DelFlg));

            if (searchDto.BirthdayFrom.HasValue) predicate.And(u => searchDto.BirthdayFrom >= u.Birthday);
            if (searchDto.BirthdayTo.HasValue) predicate.And(u => searchDto.BirthdayTo <= u.Birthday);

            if (searchDto.DateCreatedFrom.HasValue) predicate.And(u => u.DateCreated >= searchDto.DateCreatedFrom);
            if (searchDto.DateCreatedTo.HasValue) predicate.And(u => u.DateCreated <= searchDto.DateCreatedTo);

            if (searchDto.DateChangedFrom.HasValue) predicate.And(u => u.DateChanged <= searchDto.DateCreatedFrom);
            if (searchDto.DateChangedTo.HasValue) predicate.And(u => u.DateChanged >= searchDto.DateCreatedTo);

            return predicate;
        }
    }
}
