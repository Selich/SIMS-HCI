using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.Services.State
{
    class RejectedState : IPropositionState
    {
        public void Approve()
        {
            throw new NotImplementedException();
        }

        public void Reject()
        {
            throw new NotImplementedException();
        }
    }
}
