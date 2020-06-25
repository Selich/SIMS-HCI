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
        private readonly IPropositionRepository _propositionRepository;

        public PropositionService(
            IPropositionRepository prescriptionRepository
            )
        {
            _propositionRepository = prescriptionRepository;
        }
        public IEnumerable<Proposition> GetAll() 
            => _propositionRepository.GetAll();
        public Proposition GetById(long id)
            => _propositionRepository.GetById(id);
        public Proposition Save(Proposition prescription)
            => _propositionRepository.Save(prescription);
        
        //TODO add state methods
        public Proposition Update(Proposition prescription)
            => _propositionRepository.Update(prescription);

        public Proposition Remove(Proposition prescription)
            => _propositionRepository.Remove(prescription);

    }
}
