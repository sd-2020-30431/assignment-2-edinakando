using Microsoft.AspNetCore.Mvc;
using System;
using WastelessAPI.Application.Logic;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharitiesController : ControllerBase
    {
        private CharitiesLogic _charitiesLogic;

        public CharitiesController(CharitiesLogic charitiesLogic)
        {
            _charitiesLogic = charitiesLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(_charitiesLogic.GetCharities());
        }

        [HttpPost]
        [Route("donate")]
        public IActionResult Donate([FromBody]Donation donation)
        {
            _charitiesLogic.Donate(donation);
            return Ok();
        }
    }
}