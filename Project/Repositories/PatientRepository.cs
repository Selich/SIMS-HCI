using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;


namespace Project.Repositories
{
    public class PatientRepository : CSVRepository<Client, long>, IClientRepository, IEagerCSVRepository<Client, long>
    {
        private const string ENTITY_NAME = "Patient";
        private readonly IEagerCSVRepository<Address, long> _addressRepository;

        public PatientRepository(ICSVStream<Patient> stream, ISequencer<long> sequencer, IEagerCSVRepository<Account, long> accountRepository) : base(ENTITY_NAME, stream, sequencer) {
            _addressRepository = addressRepository;
        }

        public new IEnumerable<Patient> Find(Func<Patient, bool> predicate) => GetAllEager().Where(predicate);

        public IEnumerable<Patient> GetAllEager()
        {
            var address = _addressRepository.GetAllEager();
            var patients = GetAll();
            BindAccountsWithClients(address, patients);
            return patients;
        }

        public Patient GetEager(long id)
        {
            var patient = Get(id);
            patient.Address = _addressRepository.GetEager(patient.Address.Id);
            return patient;
        }

        private void BindAddressWithPAtient(IEnumerable<Address> addressses, IEnumerable<Patient> patients)
           => patients
           .ToList()
           .ForEach(patient = patient.Address = GetAddressById(addresses, patient.Id));

        private Address GetAccountById(IEnumerable<Address> addresses, long id)
            => addresses.SingleOrDefault(address => address.Id == id);
    }
}