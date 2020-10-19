using Microsoft.EntityFrameworkCore;
using Proarch.TechBatchTask.Core.Application.Repositories;
using Proarch.TechBatchTask.Core.Domain.Models;
using Proarch.TechBatchTask.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.TechBatchTask.Infrastructure.Data.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        private readonly TechBatchTaskDbContext _context;
        public ItemRepository(TechBatchTaskDbContext context)
        {
            _context = context;
        }

        async Task<int> IItemRepository.AddItemAsync(ItemModel item)
        {
            var itemExist = await _context.Items.SingleOrDefaultAsync(i=>i.Id == item.Id);
            if (itemExist != null)
            {
                return 0;
            }
            _context.Items.Add(item);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return item.Id;
            
        }

        async Task<List<ItemModel>> IItemRepository.GetItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

    }
}
