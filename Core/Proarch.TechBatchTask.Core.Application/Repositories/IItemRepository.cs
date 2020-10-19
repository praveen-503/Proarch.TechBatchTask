using Proarch.TechBatchTask.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.TechBatchTask.Core.Application.Repositories
{
    public interface IItemRepository
    {
        Task<List<ItemModel>> GetItemsAsync();
        Task<int> AddItemAsync(ItemModel item);
    }
}
