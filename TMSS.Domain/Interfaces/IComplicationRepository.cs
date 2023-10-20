using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;

namespace TMSS.Domain.Interfaces
{
    public interface IComplicationRepository
    {
        ComplicationDto SaveProcedure(ComplicationDto complicationDto);
        Task<IEnumerable<ComplicationDto>> GetComplications();
    }
}
