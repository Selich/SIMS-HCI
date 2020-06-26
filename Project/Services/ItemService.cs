using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repositories;
using Project.Repositories.Abstract;

namespace Project.Services
{

    public class ItemService : IService<Item, long>
    {
        private readonly ItemRepository _itemRepository;

        public ItemService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> GetAll() 
            => _itemRepository.GetAll();

        public Item GetById(long id) 
            => _itemRepository.GetById(id);

        public Item Save(Item address) 
            => _itemRepository.Save(address); 

        public Item Update(Item address) 
            => _itemRepository.Update(address);

        public Item Remove(Item address) 
            => _itemRepository.Remove(address);

    }
}