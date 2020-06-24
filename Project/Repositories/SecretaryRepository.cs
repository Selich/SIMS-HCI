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
    public class SecretaryRepository:
        CSVRepository<Secretary, long>,
        ISecretaryRepository,
        IEagerCSVRepository<Secretary, long>
    {
        private const string ENTITY_NAME = "Secretary";

        public SecretaryRepository(
            ICSVStream<Secretary> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            //Dodati vezu ka QustionsRepo i AddressRepo za Eager
        }
        public new IEnumerable<Secretary> Find(Func<Secretary, bool> predicate) => GetAllEager().Where(predicate);
        public IEnumerable<Secretary> GetAllEager() => GetAll();
        public Secretary GetEager(long id) => GetById(id);

    }
}