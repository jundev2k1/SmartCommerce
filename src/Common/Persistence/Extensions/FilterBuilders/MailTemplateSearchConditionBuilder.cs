// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<MailTemplate, bool>> GetMailTemplateFilters(MailTemplateFilterModel filter)
		{
			var predicate = PredicateBuilder.True<MailTemplate>();

			if (string.IsNullOrEmpty(filter.Keywords) == false)
			{
				predicate.And(mail => mail.MailId.ToString().Contains(filter.Keywords)
					|| mail.Subject.Contains(filter.Keywords));
			}

			if (string.IsNullOrEmpty(filter.BranchId) == false)
			{
				predicate.And(mail => mail.BranchId.Equals(filter.BranchId));
			}

			if (string.IsNullOrEmpty(filter.MailId) == false)
			{
				predicate.And(mail => mail.MailId.Equals(filter.MailId));
			}

			return predicate;
		}
	}
}
