using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface ICompilationService
    {
        ComplicationDto SaveComplication(ComplicationDto complicationDto);
        Task<IEnumerable<ComplicationDto>> GetComplications();
    }
}
