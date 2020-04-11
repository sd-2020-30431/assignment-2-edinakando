using Microsoft.AspNetCore.Mvc;
using System;
using WastelessAPI.Application.Factory;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Reports;
using WastelessAPI.DataAccess;

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private WastelessDbContext _context;

        public ReportsController(WastelessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(ReportType type, Int32 userId)
        {
            IAbstractReportFactory factory = null;

            if(type == ReportType.Weekly)
            {
                factory = new WeeklyReportFactory();
            }
            else if(type == ReportType.Monthly)
            {
                factory = new MonthlyReportFactory();
            }

            return new JsonResult(new ReportLogic(factory, _context).GetReport(userId));
        }
    }
}
