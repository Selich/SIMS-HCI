using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.Referral
{
    public class OperationReferralRepository : IReferralRepository
    {
        public IEnumerable<Model.Referral> Find(Func<Model.Referral, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Referral> GetAll()
        {
            throw new NotImplementedException();
        }

        public Model.Referral GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Model.Referral Remove(Model.Referral entity)
        {
            throw new NotImplementedException();
        }

        public Model.Referral Save(Model.Referral entity)
        {
            throw new NotImplementedException();
        }

        public Model.Referral Update(Model.Referral entity)
        {
            throw new NotImplementedException();
        }
    }
}
