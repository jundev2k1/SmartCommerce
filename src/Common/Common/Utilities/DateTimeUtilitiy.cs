// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Common.Utilities
{
	public static class DateTimeUtilitiy
	{
		/// <summary>
		/// Calculate days from that date input to now
		/// </summary>
		/// <param name="date">Date input</param>
		/// <returns>Number of days since then</returns>
		public static string ToTotalDays(this DateTime date, Dictionary<string, string> localizer)
		{
			// Calculate total date
			var totalDays = Convert.ToInt32((DateTime.Now - date).TotalDays);

			// Check total day, is date greater than 1 year?
			if (totalDays > 365)
			{
				var years = totalDays / 365;
				var messageFormat = localizer["StringFormat_YearsAgo"];
				return string.Format(messageFormat, years);
			}

			// Check total day, is that date greater than 1 month?
			if (totalDays > 30)
			{
				var month = totalDays / 30;
				var messageFormat = localizer["StringFormat_MonthsAgo"];
				return string.Format(messageFormat, month);
			}

			var dayMessageFormat = localizer["StringFormat_DaysAgo"];
			return string.Format(dayMessageFormat, totalDays.ToString());
		}
	}
}
