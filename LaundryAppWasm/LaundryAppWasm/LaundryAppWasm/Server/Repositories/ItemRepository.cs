using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace LaundryAppWasm.Server.Repositories
{
    public class ItemRepository : IItem
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateITem(ItemDTO itemDto)
        {
            var item = new Item
            {
                Name = itemDto.Name,
                Type = (Models.Type)itemDto.Type,
                Description = itemDto.Description,
            };
            try
            {
                _context.Item.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteItem(int Id)
        {
            var item = _context.Item.FirstOrDefault(x => x.Id == Id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return true;
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
