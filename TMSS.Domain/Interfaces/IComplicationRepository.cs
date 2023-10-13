using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface IComplicationRepository
    {
        Task<IEnumerable<Complication>> GetComplication();
        Complication CreateComplication(Complication complication);
        Complication ModifyComplication(Complication complication);
    }
}
