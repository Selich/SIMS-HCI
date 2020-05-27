using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;

namespace Project.Repositories
{
    public class PatientRepository { 
        //: CSVRepository<Patient, long>, IPatientRepository, IEagerCSVRepository<Patient, long>
    //{
    //    private const string ENTITY_NAME = "Patient";
    //    private readonly IEagerCSVRepository<Address, long> _addressRepository;
    //    private CSVStream<Address> cSVStream;
    //    private LongSequencer longSequencer;

    //    public PatientRepository(CSVStream<Address> cSVStream, LongSequencer longSequencer)
    //    {
    //        this.cSVStream = cSVStream;
    //        this.longSequencer = longSequencer;
    //    }

    //    public PatientRepository(ICSVStream<Patient> stream, ISequencer<long> sequencer, IEagerCSVRepository<Account, long> accountRepository) : base(ENTITY_NAME, stream, sequencer) {
    //        _addressRepository = addressRepository;
    //    }

    //    public new IEnumerable<Patient> Find(Func<Patient, bool> predicate) => GetAllEager().Where(predicate);

    //    public IEnumerable<Patient> GetAllEager()
    //    {
    //        var address = _addressRepository.GetAllEager();
    //        var patients = GetAll();
    //        BindAddressWithPatient(address, patients);
    //        return patients;
    //    }

    //    public Patient GetEager(long id)
    //    {
    //        var patient = Get(id);
    //        patient.Address = _addressRepository.GetEager(patient.Address.Id);
    //        return patient;
    //    }

    //    private void BindAddressWithPatient(IEnumerable<Address> addressses, IEnumerable<Patient> patients)
    //       => patients
    //       .ToList()
    //       .ForEach(patient = patient.Address = GetAddressById(addresses, patient.Id));

    //    private Address GetAccountById(IEnumerable<Address> addresses, long id)
    //        => addresses.SingleOrDefault(address => address.Id == id);
    }
}