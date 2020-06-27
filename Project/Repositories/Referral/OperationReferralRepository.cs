using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Referrals;
using Project.Repositories.Abstract;
using Project.Repositories.CSV;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;

namespace Project.Repositories.Referral
{
    public class OperationReferralRepository:
        CSVRepository<OperationReferral, long>,
        IRepository<OperationReferral, long>
    {
        private const string ENTITY_NAME = "OperationReferral";

        public OperationReferralRepository(
            ICSVStream<OperationReferral> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public IEnumerable<OperationReferral> Find(Func<OperationReferral, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperationReferral> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperationReferral> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public OperationReferral GetById(long id)
        {
            throw new NotImplementedException();
        }

        public OperationReferral GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public OperationReferral Remove(OperationReferral entity)
        {
            throw new NotImplementedException();
        }

        public OperationReferral Save(OperationReferral entity)
        {
            throw new NotImplementedException();
        }

        public OperationReferral Update(OperationReferral entity)
        {
            throw new NotImplementedException();
        }
    }
}
