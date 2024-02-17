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
        /// <returns>Display price</returns>
        public static string GetProductDisplayPrice(ProductModel product)
        {
            var result = product.DisplayPrice switch
            {
                DisplayPriceEnum.Price1 => product.Price1.ToString("G29"),
                DisplayPriceEnum.Price2 => product.Price1.ToString("G29"),
                DisplayPriceEnum.Price3 => product.Price1.ToString("G29"),
                _ => string.Empty
            };
            return result;
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

        public static string GetUserSex(SexEnum sex)
        {
            var result = sex switch
            {
                SexEnum.Male => "Male",
                SexEnum.Female => "Female",
                SexEnum.Other => "Other",
                _ => "This sex not exists"
            };
            return result;
        }
    }
}
