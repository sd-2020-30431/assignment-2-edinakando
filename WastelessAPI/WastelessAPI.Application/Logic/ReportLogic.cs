
using System;
using System.Collections.Generic;
using WastelessAPI.Application.Factory;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Application.Models.Reports;
using WastelessAPI.DataAccess;

namespace WastelessAPI.Application.Logic
{
    public class ReportLogic
    {
        private IReport _report;

        public ReportLogic(IAbstractReportFactory factory, WastelessDbContext context)
        {
            _report = factory.CreateReport(context);
        }

        public IList<GroceryItem> GetReport(Int32 userId)
        {
           return  _report.GetReport(userId);
        }
    }
}
