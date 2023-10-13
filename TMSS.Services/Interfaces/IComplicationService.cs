using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.Entities;

namespace TMSS.Services.Interfaces
{
    public interface IComplicationService
    {
        Task<IEnumerable<Complication>> GetComplications();
        Complication CreateComplication(Complication complication);
        Complication ModifyComplication(Complication complication);
    }
}
