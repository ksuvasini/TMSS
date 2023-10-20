using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Web.Models;

namespace TMSS.Domain.Interfaces
{
    public interface ISurgeonRepository
    {
        Task<IEnumerable<SurgeonDto>> GetSurgeons();

        Task<SurgeonDto> SaveSurgeon(SurgeonDto clinic);
    }
}
