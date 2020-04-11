using WastelessAPI.Application.Models.Reports;
using WastelessAPI.DataAccess;

namespace WastelessAPI.Application.Factory
{
    public class WeeklyReportFactory : IAbstractReportFactory
    {
        public IReport CreateReport(WastelessDbContext context)
        {
            return new WeeklyReport(context);
        }
    }
}
