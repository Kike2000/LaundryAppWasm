using LaundryAppWasm.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppWasm.Shared.Interfaces
{
    public interface IItem
    {
        Task<IEnumerable<ItemDTO>> GetItemsAsync();
        Task CreateITem(ItemDTO item);
    }
}
