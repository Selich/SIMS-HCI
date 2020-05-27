using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System.Collections.Generic;
using System.Linq;

namespace Project.Repositories
{
    public class AddressRepository 
    //CSVRepository<Address, long>
        //IAddressRepository,
        //IEagerCSVRepository<Address, long>
    {
        private const string ENTITY_NAME = "Address";


        //public AddressRepository(ICSVStream<Address> stream, ISequencer<long> sequencer)
        //    : base(ENTITY_NAME, stream, sequencer)
        //{
        //}

        //public new Address Create(Address Address)
        //{
        //    if (IsAddressNumberUnique(Address.Number))
        //        return base.Create(Address);
        //    else
        //        throw new Exception();
        //}

        //private bool IsAddressNumberUnique(AddressNumber AddressNumber)
        //   => GetAddressByAddressName(AddressNumber) == null;

        //private Address GetAddressByAddressName(AddressNumber AddressNumber)
        //    => _stream.ReadAll().SingleOrDefault(Address => Address.Number.Equals(AddressNumber));

        //public Address GetEager(long id) => Get(id);

        //public IEnumerable<Address> GetAllEager() => GetAll();
    }
}
