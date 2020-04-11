using WastelessAPI.Application.Models.Reports;
using WastelessAPI.DataAccess;

namespace WastelessAPI.Application.Factory
{
    public interface IAbstractReportFactory
    {
        public IReport CreateReport(WastelessDbContext context);
    }
}