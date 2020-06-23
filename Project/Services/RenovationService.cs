using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class RenovationService: IService<Renovation,long>
    {
        private readonly IRenovationRepository _renovationRepository;

        public RenovationService(IRenovationRepository renovationRepository)
        {
            _renovationRepository = renovationRepository;
        }

        public IEnumerable<Renovation> GetAll()
            => _renovationRepository.GetAll();

        public Renovation GetById(long id)
            => _renovationRepository.GetById(id);

        public Renovation Save(Renovation renovation)
            => _renovationRepository.Save(renovation);

        public Renovation Update(Renovation renovation)
            => _renovationRepository.Update(renovation);

        public Renovation Remove(Renovation renovation)
            => _renovationRepository.Remove(renovation);
    }
}
