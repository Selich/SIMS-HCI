using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.State
{
    public interface IPropositionState
    {
        string Approve();
        string Reject();
    }
}
