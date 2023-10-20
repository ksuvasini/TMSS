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
    public class ClinicRepository : IClinicRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public ClinicRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public  IEnumerable<Clinic> GetClinics()
        {
            return  _tMSSDbContext.Clinic.ToList();
        }

        public Clinic CreateClinic(Clinic clinic)
        {
            var _clinic = _tMSSDbContext.Clinic.Add(clinic);
            if (_clinic.Context.SaveChanges() == 1)
                return _clinic.Entity;
            else
                return new Clinic();

        }

        public Clinic ModifyClinic(Clinic clinic)
        {
            var existingClinic = _tMSSDbContext.Clinic.FirstOrDefault(u => u.ClinicId == clinic.ClinicId);
            if (existingClinic != null)
            {
                existingClinic.ClinicName = clinic.ClinicName;
                existingClinic.ClinicLocation = clinic.ClinicLocation;
                existingClinic.ModifiedDate = DateTime.Now;
                existingClinic.ModifiedBy = "admin";
                var _clinic = _tMSSDbContext.Clinic.Update(existingClinic);
                if (_clinic.Context.SaveChanges() == 1)
                    return _clinic.Entity;
            }

            return new Clinic();
        }
    }
}
