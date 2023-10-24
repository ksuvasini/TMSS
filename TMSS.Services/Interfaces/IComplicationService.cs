﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;

namespace TMSS.Services.Interfaces
{
    public interface IComplicationService
    {
        Task<IEnumerable<ComplicationDto>> GetComplications();
        ComplicationDto SaveComplication(ComplicationDto complicationDto);
    }
}
