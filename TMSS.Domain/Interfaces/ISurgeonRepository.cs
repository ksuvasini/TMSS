using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface ISurgeonRepository
    {
        Task<IEnumerable<Surgeon>> GetSurgeon();
        Surgeon CreateSurgeon(Surgeon surgeon);
        Surgeon ModifySurgeon(Surgeon surgeon);
    }
}
