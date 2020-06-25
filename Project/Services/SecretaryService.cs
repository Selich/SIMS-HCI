using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class SecretaryService: IService<Secretary,long>
    {
        private readonly ISecretaryRepository _secretaryRepository;
        private readonly IService<Address, long> _addressService;

        public SecretaryService(ISecretaryRepository secretaryRepository, IService<Address, long> addressService)
        {
            _secretaryRepository = secretaryRepository;
            _addressService = addressService;
        }

        public IEnumerable<Secretary> GetAll()
        {
            var secretaries = _secretaryRepository.GetAll();
            var addresses = _addressService.GetAll();
            BindSecretaryWithAddress(addresses, secretaries);
            return secretaries;
        }

        public Secretary GetById(long id)
        {
            var secretary = _secretaryRepository.GetById(id);
            secretary.Address = _addressService.GetById(secretary.Address.Id);
            return secretary;
        }

        public Secretary Remove(Secretary secretary)
        => _secretaryRepository.Remove(secretary);

        public Secretary Save(Secretary secretary)
        {
            var address = _addressService.Save(secretary.Address);
            var newSecretary = _secretaryRepository.Save(secretary);
            newSecretary.Address = address;
            return newSecretary;
        }

        public Secretary Update(Secretary secretary)
        {
            _addressService.Update(secretary.Address);
            var Secretary=_secretaryRepository.Update(secretary);
            return Secretary;
        }

        private void BindSecretaryWithAddress(IEnumerable<Address> addresses, IEnumerable<Secretary> secretaries)
            => secretaries
            .ToList()
            .ForEach(sec => sec.Address = _addressService.GetById(sec.Address.Id));
    }
}
