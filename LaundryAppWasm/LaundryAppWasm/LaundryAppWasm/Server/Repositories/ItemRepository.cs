using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaundryAppWasm.Server.Repositories
{
    public class ItemRepository : IItem
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            return await _context.Item
             .Select(c => new ItemDTO
             {
                 Id = c.Id,
                 Description= c.Description,
                 Name= c.Name,
                 Type= Shared.DTOs.Type.Shirt
             })
             .ToListAsync();
        }
    }
}
