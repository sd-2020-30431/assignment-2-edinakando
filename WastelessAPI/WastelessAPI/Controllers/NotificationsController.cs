using Microsoft.AspNetCore.Mvc;
using System;
using WastelessAPI.Application.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private GroceriesLogic _groceriesLogic;

        public NotificationsController(GroceriesLogic groceriesLogic)
        {
            _groceriesLogic = groceriesLogic;
        }

        [Route("Expiration")]
        [HttpGet]
        public IActionResult GetExpirationNotification(Int32 userId)
        {
            return new JsonResult(_groceriesLogic.GetExpirationNotification(userId));
        }
    }
}
