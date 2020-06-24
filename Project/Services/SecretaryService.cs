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

        public SecretaryService(ISecretaryRepository secretaryRepository)
        {
            _secretaryRepository = secretaryRepository;
        }

        public IEnumerable<Secretary> GetAll()
          => _secretaryRepository.GetAll();

        public Secretary GetById(long id)
        => _secretaryRepository.GetById(id);

        public Secretary Remove(Secretary secretary)
        => _secretaryRepository.Remove(secretary);

        public Secretary Save(Secretary secretary)
        => _secretaryRepository.Save(secretary);

        public Secretary Update(Secretary secretary)
        => _secretaryRepository.Update(secretary);
    }
}
