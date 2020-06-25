using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Services.State
{
    class InReviewState : IPropositionState
    {

        public Proposition Approve(Proposition proposition)
        {
            throw new NotImplementedException();
        }

        public Proposition Reject(Proposition proposition)
        {
            throw new NotImplementedException();
        }
    }
}
