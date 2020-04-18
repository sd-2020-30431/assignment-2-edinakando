using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Groceries;

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private GroceriesLogic _groceriesLogic;

        public GroceriesController(GroceriesLogic groceriesLogic)
        {
            _groceriesLogic = groceriesLogic;
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]Groceries groceries)
        {
            _groceriesLogic.Save(groceries);
            return Ok();
        }

        [HttpGet]
        public IActionResult Index(Int32 userId)
        {
            return new JsonResult(_groceriesLogic.GetGroceries(userId));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]IList<GroceryItem> groceries)
        {
            _groceriesLogic.Edit(groceries);
            return Ok();
        }
    }
}