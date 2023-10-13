using AutoMapper;
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
    public class ComplicationRepository : IComplicationRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public ComplicationRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Complication>> GetComplication()
        {
            return await _tMSSDbContext.Complication.ToListAsync();
        }
        public Complication CreateComplication(Complication complication)
        {
            var _complication = _tMSSDbContext.Complication.Add(complication);
            if (_complication.Context.SaveChanges() == 1)
                return _complication.Entity;
            else
                return new Complication();

        }
        public Complication ModifyComplication(Complication complication)
        {
            var existingComplication = _tMSSDbContext.Complication.FirstOrDefault(u => u.ComplicationId == complication.ComplicationId);
            if (existingComplication != null)
            {
                existingComplication.ComplicationName = complication.ComplicationName;
                existingComplication.ModifiedDate = DateTime.Now;
                existingComplication.ModifiedBy = "admin";
                var _complication = _tMSSDbContext.Complication.Update(existingComplication);
                if (_complication.Context.SaveChanges() == 1)
                    return _complication.Entity;
            }

            return new Complication();
        }

    }
}
