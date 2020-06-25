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
        private readonly IAddressRepository _addressRepository;

        public SecretaryRepository(
            ICSVStream<Secretary> stream,
            IAddressRepository addressRepository,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
            _addressRepository = addressRepository;
        }
        public IEnumerable<Secretary> GetAllEager() 
            => GetAll();
        public Secretary GetEager(long id) 
            => GetById(id);
        public new IEnumerable<Secretary> Find(Func<Secretary, bool> predicate) 
            => GetAllEager().Where(predicate);

        public new IEnumerable<Secretary> GetAll() 
        {
            var secretaries = GetAll();
            var addresses = _addressRepository.GetAll();
            BindSecretaryWithAddress(addresses, secretaries);
            return secretaries;
        }

        public new Secretary GetById(long id) 
        {
            var secretary = GetById(id);
            secretary.Address = _addressRepository.GetById(secretary.Address.Id);
            return secretary;
        }
        public new Secretary Save(Secretary entity) 
        {
            entity.Address = _addressRepository.Save(entity.Address);
            return base.Save(entity);
        }
        public Secretary Update(Secretary entity) 
        {
            entity.Address = _addressRepository.Save(entity.Address);
            return Update(entity);
        }
        private void BindSecretaryWithAddress(IEnumerable<Address> addresses, IEnumerable<Secretary> secretaries)
            => secretaries
            .ToList()
            .ForEach(sec => sec.Address = _addressRepository.GetById(sec.Address.Id));

    }
}