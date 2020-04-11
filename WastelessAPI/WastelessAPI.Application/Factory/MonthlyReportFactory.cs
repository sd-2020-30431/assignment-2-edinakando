
using WastelessAPI.Application.Models.Reports;
using WastelessAPI.DataAccess;

namespace WastelessAPI.Application.Factory
{
    public class MonthlyReportFactory : IAbstractReportFactory
    {
        public IReport CreateReport(WastelessDbContext context)
        {
            return new MonthlyReport(context);
        }
    }
}
