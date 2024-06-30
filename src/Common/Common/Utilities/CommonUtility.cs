// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common.Utilities
{
	public static class CommonUtility
	{
		/// <summary>
		/// Handle limit page
		/// </summary>
		/// <param name="pageIndex">Page index</param>
		/// <param name="totalPage">Total page</param>
		/// <param name="isPrevious">Is handle for previous button, otherwise for next button</param>
		/// <returns>Next page or previous page with current page</returns>
		public static int HandleLimitPage(int pageIndex, int totalPage, bool isPrevious = true)
		{
			if (isPrevious)
			{
				var previousPage = pageIndex - 1;
				return (previousPage > 0) ? previousPage : 1;
			}

			var nextPage = pageIndex + 1;
			return (pageIndex < totalPage) ? nextPage : totalPage;
		}

		/// <summary>
		/// Get product display price
		/// </summary>
		/// <param name="product">Model</param>
		/// <param name="prefix">Text prefix</param>
		/// <returns>Display price</returns>
		public static string GetProductDisplayPrice(ProductModel product, string prefix = "")
		{
			var result = product.DisplayPrice switch
			{
				DisplayPriceEnum.Price1 => GetProductPrice(product.Price1, prefix),
				DisplayPriceEnum.Price2 => GetProductPrice(product.Price2, prefix),
				DisplayPriceEnum.Price3 => GetProductPrice(product.Price3, prefix),
				_ => string.Empty
			};
			return result;
		}

		/// <summary>
		/// Get product price
		/// </summary>
		/// <param name="price">Price</param>
		/// <param name="prefix">Prefix</param>
		/// <returns>Product price</returns>
		public static string GetProductPrice(decimal price, string prefix = "")
		{
			return $"{price.ToPrice()} {prefix}".Trim();
		}

		/// <summary>
		/// Calculate time
		/// </summary>
		/// <param name="date">Date</param>
		/// <returns>Time after subtracting the current time</returns>
		public static (int Years, int Months, int Days, int Hours, int Minutes, int Seconds) CalculateTime(DateTime date)
		{
			var Now = DateTime.Now;
			int Years = new DateTime(DateTime.Now.Subtract(date).Ticks).Year - 1;
			var PastYearDate = date.AddYears(Years);
			int Months = 0;

			for (int i = 1; i <= 12; i++)
			{
				if (PastYearDate.AddMonths(i) == Now)
				{
					Months = i;
					break;
				}
				else if (PastYearDate.AddMonths(i) >= Now)
				{
					Months = i - 1;
					break;
				}
			}

			return (
				Years,
				Months,
				Days: Now.Subtract(PastYearDate.AddMonths(Months)).Days,
				Hours: Now.Subtract(PastYearDate).Hours,
				Minutes: Now.Subtract(PastYearDate).Minutes,
				Seconds: Now.Subtract(PastYearDate).Seconds);
		}

		/// <summary>
		/// Get user sex
		/// </summary>
		/// <param name="sex">Sex</param>
		/// <returns>User sex</returns>
		public static string GetUserSex(UserSexEnum sex)
		{
			var result = sex switch
			{
				UserSexEnum.Male => "Male",
				UserSexEnum.Female => "Female",
				UserSexEnum.Other => "Other",
				_ => "This sex not exists"
			};
			return result;
		}

		/// <summary>
		/// Get product address
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Product address</returns>
		public static string GetProductAddress(ProductModel model)
		{
			return string.Empty;
		}
	}
}
