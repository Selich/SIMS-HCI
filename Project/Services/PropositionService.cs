using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class PropositionService : IService<Proposition, long>
    {
        private readonly IRepository<Proposition, long> _propositionRepository;

        public PropositionService(
            IRepository<Proposition, long> propositionRepository
            )
        {
            _propositionRepository = propositionRepository;
        }
        public IEnumerable<Proposition> GetAll() 
            => _propositionRepository.GetAll();
        public Proposition GetById(long id)
            => _propositionRepository.GetById(id);
        public Proposition Save(Proposition prescription)
            => _propositionRepository.Save(prescription);

        public Proposition Update(Proposition prescription)
            => _propositionRepository.Update(prescription);

        public Proposition Remove(Proposition prescription)
            => _propositionRepository.Remove(prescription);

    }
}
