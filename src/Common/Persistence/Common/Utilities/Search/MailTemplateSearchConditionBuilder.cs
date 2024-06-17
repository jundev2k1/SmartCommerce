// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618

namespace ErpManager.Persistence.Common.Utilities.Search
{
    public partial class SearchConditionBuilder
    {
        public static Expression<Func<MailTemplate, bool>> MailTemplateSearch(MailTemplateSearchDto searchDto)
        {
            var predicate = PredicateBuilder.True<MailTemplate>();

            if (string.IsNullOrEmpty(searchDto.Keywords) == false)
            {
                predicate.And(p =>
                    p.MailId.ToString().Contains(searchDto.Keywords)
                    || p.Subject.Contains(searchDto.Keywords));
            }

            if (string.IsNullOrEmpty(searchDto.BranchId) == false)
            {
                predicate.And(u => u.BranchId.Contains(searchDto.BranchId));
            }

            return predicate;
        }
    }
}
