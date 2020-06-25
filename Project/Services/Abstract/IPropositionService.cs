using System.Collections.Generic;
using Project.Model;

namespace Project.Services
{
    public interface IPropositionService : IService<Proposition,long>
    {
        void Approve(Proposition proposition);
        void Reject(Proposition proposition);
    }
}
