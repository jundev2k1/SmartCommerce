// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Models
{
	public class ModelBase<TModel>
	{
		/// <summary>
		/// Clone model
		/// </summary>
		/// <returns>A copy of the model</returns>
		public virtual ModelBase<TModel> Clone()
		{
			return (ModelBase<TModel>)this.MemberwiseClone();
		}

		/// <summary>
		/// Is equal model
		/// </summary>
		/// <param name="model">Order model</param>
		/// <returns>Is equal?</returns>
		public virtual bool IsEqual(ModelBase<TModel> model)
		{
			var result = (model != null)
				? this.Equals(model)
				: false;
			return result;
		}

		public PropertyExtensions<TModel> Properties { get; } = new PropertyExtensions<TModel>();
	}
}
