// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Models
{
	public abstract class ModelBase
	{
		/// <summary>
		/// Clone model
		/// </summary>
		/// <returns>A copy of the model</returns>
		public virtual ModelBase Clone()
		{
			return (ModelBase)this.MemberwiseClone();
		}

		/// <summary>
		/// Is equal model
		/// </summary>
		/// <param name="model">Order model</param>
		/// <returns>Is equal?</returns>
		public virtual bool IsEqual(ModelBase model)
		{
			var result = (model != null)
				? this.Equals(model)
				: false;
			return result;
		}
	}
}
