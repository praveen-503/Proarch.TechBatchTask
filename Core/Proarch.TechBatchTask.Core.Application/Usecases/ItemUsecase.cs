using Proarch.TechBatchTask.Core.Application.Repositories;
using Proarch.TechBatchTask.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.TechBatchTask.Core.Application.Usecases
{
    public interface IItemUsecase
    {
        Task<List<ItemModel>> GetItemsAsyc();
        Task<int> AddItemAsync(ItemModel item);
    }
    internal class ItemUsecase : IItemUsecase
    {
        private readonly IItemRepository _itemRepo;
        public ItemUsecase(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }

        async Task<int> IItemUsecase.AddItemAsync(ItemModel item)
        {
            return await _itemRepo.AddItemAsync(item);
            throw new NotImplementedException();
        }

        async Task<List<ItemModel>> IItemUsecase.GetItemsAsyc()
        {
           return await _itemRepo.GetItemsAsync();
            throw new NotImplementedException();
        }
    }
}
