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
        int SaveComplication(ComplicationDto complicationDto);
        Task<List<ComplicationDto>> GetComplications(string? complicationName);
    }
}
