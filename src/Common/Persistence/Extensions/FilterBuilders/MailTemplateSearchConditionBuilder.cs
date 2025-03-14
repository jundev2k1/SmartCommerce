// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<MailTemplate, bool>> GetMailTemplateFilters(MailTemplateFilterModel input)
		{
			var predicate = PredicateBuilder.True<MailTemplate>();

			if (string.IsNullOrEmpty(input.Keywords) == false)
			{
				predicate.And(mail => mail.MailId.ToString().Contains(input.Keywords)
					|| mail.Subject.Contains(input.Keywords));
			}

			if (string.IsNullOrEmpty(input.BranchId) == false)
			{
				predicate.And(mail => mail.BranchId.Equals(input.BranchId));
			}

			if (string.IsNullOrEmpty(input.MailId) == false)
			{
				predicate.And(mail => mail.MailId.Equals(input.MailId));
			}

			return predicate;
		}
	}
}
