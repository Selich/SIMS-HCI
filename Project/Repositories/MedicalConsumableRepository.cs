using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class MedicalConsumableRepository :
        CSVRepository<MedicalConsumables, long>,
        IMedicalConsumableRepository
    {
        private const string ENTITY_NAME = "MedicalConsumables";
        
        public MedicalConsumableRepository(
            ICSVStream<MedicalConsumables> stream,
            ISequencer<long> sequencer
            ):base(ENTITY_NAME, stream, sequencer) { }

        public new IEnumerable<MedicalConsumables> Find(Func<MedicalConsumables, bool> predicate) => GetAll().Where(predicate);

    }
}
