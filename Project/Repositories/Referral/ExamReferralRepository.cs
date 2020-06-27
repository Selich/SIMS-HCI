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
    public class ExamReferralRepository:
        CSVRepository<ExamReferral, long>,
        IRepository<ExamReferral, long>
    {
        private const string ENTITY_NAME = "ExamReferral";

        public ExamReferralRepository(
            ICSVStream<ExamReferral> stream,
            ISequencer<long> sequencer
            ) : base(ENTITY_NAME, stream, sequencer)
        {
        }
        public IEnumerable<ExamReferral> Find(Func<ExamReferral, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamReferral> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamReferral> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public ExamReferral GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ExamReferral GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public ExamReferral Remove(ExamReferral entity)
        {
            throw new NotImplementedException();
        }

        public ExamReferral Save(ExamReferral entity)
        {
            throw new NotImplementedException();
        }

        public ExamReferral Update(ExamReferral entity)
        {
            throw new NotImplementedException();
        }
    }
}
