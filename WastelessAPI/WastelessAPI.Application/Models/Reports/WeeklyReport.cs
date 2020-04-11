using System;
using System.Collections.Generic;
using System.Linq;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.DataAccess;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Models.Reports
{
    public class WeeklyReport : IReport
    {
        private WastelessDbContext _context;

        public WeeklyReport(WastelessDbContext context)
        {
            _context = context;
        }

        public IList<GroceryItem> GetReport(Int32 userId)
        {
            var reportRepository = new ReportRepository(_context);
            IList<DataAccess.Models.GroceryItem> wastedGroceries = reportRepository.GetWeeklyReport(userId);
            return wastedGroceries.Select(item => new GroceryItem(item)).ToList();
        }
    }
}