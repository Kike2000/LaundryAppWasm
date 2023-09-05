using LaundryAppWasm.Server.Repositories;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaundryAppWasm.Server.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private readonly IItem _itemInterface;
        public ItemController(IItem itemInterface)
        {
            this._itemInterface = itemInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> Get()
        {
            var customers = await _itemInterface.GetItemsAsync();
            return Ok(customers);
        }

    }
}
