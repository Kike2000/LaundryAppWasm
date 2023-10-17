using LaundryAppWasm.Server.Repositories;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> Get()
        {
            var customers = await _itemInterface.GetItemsAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItemDTO model)
        {
            try
            {
                await _itemInterface.CreateITem(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _itemInterface.DeleteItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }
    }
}
