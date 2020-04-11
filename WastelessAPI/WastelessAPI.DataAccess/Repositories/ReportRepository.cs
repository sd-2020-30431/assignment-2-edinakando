using System;
using System.Collections.Generic;
using System.Linq;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Repositories
{
    public class ReportRepository
    {
        private readonly WastelessDbContext _context;

        public ReportRepository(WastelessDbContext context)
        {
            _context = context;
        }

        public IList<GroceryItem> GetWeeklyReport(Int32 userId)
        {
            var groceryItems = _GetUserGroceries(userId);
            return groceryItems.Where(item => _IsWaste(item) && _IsFromCurrentWeek(item.ExpirationDate))
                            .ToList();
        }

        public IList<GroceryItem> GetMonthlyReport(Int32 userId)
        {
            var groceryItems = _GetUserGroceries(userId);
            return groceryItems.Where(item => _IsWaste(item) && _IsFromCurrentMonth(item.ExpirationDate))
                            .ToList();
        }

        private Boolean _IsFromCurrentWeek(DateTime date)
        {
            var calendar = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var currentDate = DateTime.Now;
            var dateOfWeek = date.Date.AddDays(-1 * (int)calendar.GetDayOfWeek(date));
            var currentOfWeek = currentDate.Date.AddDays(-1 * (int)calendar.GetDayOfWeek(currentDate));

            return dateOfWeek == currentOfWeek;
        }

        private Boolean _IsFromCurrentMonth(DateTime date)
        {
            var currentDate = DateTime.Now;
            var currentMonthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            var currentMonthEndDate = currentMonthStartDate.AddMonths(1).AddDays(-1);
            return date > currentMonthStartDate && date < currentMonthEndDate;
        }

        private Boolean _IsWaste(GroceryItem grocery)
        {
            return grocery.ConsumptionDate == DateTime.MinValue && grocery.ExpirationDate < DateTime.Now;
        }

        private IList<GroceryItem> _GetUserGroceries(Int32 userId)
        {
            List<IList<GroceryItem>> groceries = _context.GroceryLists.Where(list => list.UserId == userId && list.Items.Count != 0)
                                                .Select(list => list.Items)
                                                .ToList();

            return groceries.Aggregate(new List<GroceryItem>(), (x, y) => x.Concat(y).ToList()).ToList();
        }
    }
}