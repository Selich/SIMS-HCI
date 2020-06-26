using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Repositories
{
    public class ItemRepository :
        CSVRepository<Item, long>,
        IItemRepository,
        IEagerCSVRepository<Item, long>
    {
        private const string ENTITY_NAME = "Item";

        public ItemRepository(ICSVStream<Item> stream, ISequencer<long> sequencer)
           : base(ENTITY_NAME, stream, sequencer) { }

        public new IEnumerable<Item> Find(Func<Item, bool> predicate)
            => GetAllEager().Where(predicate);


        public new Item Save(Item item)
        {
            return base.Save(item);
        }

        private bool IsItemUnique(Item items)
            => Find(item => item.Equals(items)) == null;

        public Item GetEager(long id) => GetById(id);
        public IEnumerable<Item> GetAllEager() => GetAll();
    }
}
