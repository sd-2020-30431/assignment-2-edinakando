using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WastelessAPI.Application.HubConfig;
using WastelessAPI.Application.Observer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private readonly IHubContext<NotificationsHub> _hub;
        private PushNotificationObserver _notificationObserver;
        public NotificationsController(IHubContext<NotificationsHub> hub, PushNotificationObserver notificationObserver)
        {
            _hub = hub;
            _notificationObserver = notificationObserver;
        }

        public IActionResult Get()
        {
            _hub.Clients.All.SendAsync("notificationData", _notificationObserver.GetItem());
            return Ok(new { Message = "Request Completed" });
        }
    }
}
