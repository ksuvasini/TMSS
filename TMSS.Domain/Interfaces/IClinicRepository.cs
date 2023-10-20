using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface IClinicRepository
    {
        Task<IEnumerable<ClinicDto>> GetClinic();

        Task<ClinicDto> SaveClinic(ClinicDto clinic);
    }
}
