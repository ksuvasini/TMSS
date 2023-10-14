using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.Entities;

namespace TMSS.Services.Interfaces
{
    public interface ISurgeonService
    {
        Task<IEnumerable<Surgeon>> GetSurgeon();
        Surgeon CreateSurgeon(Surgeon surgeon);
    }
}
