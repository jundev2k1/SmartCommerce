// Copyright (c) 2024 - Jun Dev. All rights reserved

using System.Linq.Expressions;

namespace ErpManager.Domain.Extensions
{
	public sealed class PropertyExtensions<TModel>
	{
		public string GetName<TProperty>(Expression<Func<TModel, TProperty>> propertyExpression)
		{
			if (propertyExpression == null)
				throw new ArgumentNullException(nameof(propertyExpression));

			if (propertyExpression.Body is MemberExpression)
			{
				return ((MemberExpression)propertyExpression.Body).Member.Name;
			}

			if (propertyExpression.Body is UnaryExpression unaryExpression)
			{
				return ((MemberExpression)unaryExpression.Operand).Member.Name;
			}

			throw new ArgumentException("Invalid property expression", nameof(propertyExpression));
		}
	}
}
