﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class SurgeonRepository : ISurgeonRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public SurgeonRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Surgeon>> GetSurgeon()
        {
            return await _tMSSDbContext.Surgeon.ToListAsync();
        }
        public Surgeon CreateSurgeon(Surgeon surgeon)
        {
            var _surgeon = _tMSSDbContext.Surgeon.Add(surgeon);
            if (_surgeon.Context.SaveChanges() == 1)
                return _surgeon.Entity;
            else
                return new Surgeon();

        }
        public Surgeon ModifySurgeon(Surgeon surgeon)
        {
            var existingSurgeon = _tMSSDbContext.Surgeon.FirstOrDefault(u => u.SurgeonId == surgeon.SurgeonId);
            if (existingSurgeon != null)
            {
                existingSurgeon.SurgeonFirstName = surgeon.SurgeonFirstName;
                existingSurgeon.SurgeonLastName = surgeon.SurgeonLastName;
                existingSurgeon.Speciality = surgeon.Speciality;
                existingSurgeon.ALSDate = surgeon.ALSDate;
                existingSurgeon.DatePPGranted = surgeon.DatePPGranted;
                existingSurgeon.DateStartedFirstCase = surgeon.DateStartedFirstCase;
                existingSurgeon.ProcedureId = surgeon.ProcedureId;
                existingSurgeon.ClinicId = surgeon.ClinicId;
                existingSurgeon.ModifiedDate = DateTime.Now;
                existingSurgeon.ModifiedBy = "admin";
                var _surgeon = _tMSSDbContext.Surgeon.Update(existingSurgeon);
                if (_surgeon.Context.SaveChanges() == 1)
                    return _surgeon.Entity;
            }

            return new Surgeon();
        }

    }
}
