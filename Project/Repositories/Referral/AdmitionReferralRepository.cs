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
    public class AdmitionReferralRepository :
        CSVRepository<AdmitionReferral, long>,
        IRepository<AdmitionReferral, long>
    {
        private const string ENTITY_NAME = "AdmitionReferral";

        public AdmitionReferralRepository(
            ICSVStream<AdmitionReferral> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public IEnumerable<AdmitionReferral> Find(Func<AdmitionReferral, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdmitionReferral> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdmitionReferral> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public AdmitionReferral GetById(long id)
        {
            throw new NotImplementedException();
        }

        public AdmitionReferral GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public AdmitionReferral Remove(AdmitionReferral entity)
        {
            throw new NotImplementedException();
        }

        public AdmitionReferral Save(AdmitionReferral entity)
        {
            throw new NotImplementedException();
        }

        public AdmitionReferral Update(AdmitionReferral entity)
        {
            throw new NotImplementedException();
        }
    }
}
