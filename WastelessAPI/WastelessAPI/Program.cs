using Coravel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WastelessAPI.Application.Scheduler;

namespace WastelessAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            host.Services.UseScheduler(scheduler =>
            {
                scheduler.Schedule<WasteLevelReminder>()
                         .DailyAt(13, 00);

                scheduler.Schedule<DonationNotification>()
                        .DailyAt(14, 30);
            });
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices( services => 
                {
                    services.AddScheduler();
                    services.AddTransient<WasteLevelReminder>();
                });
    }
}