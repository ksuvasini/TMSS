using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.WebAPI.Model;

namespace TMSS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcedureController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ProcedureController> _logger;
        private readonly IProcedureService _iProcedureService;
        private readonly IMapper _mapper;
        public ProcedureController(ILogger<ProcedureController> logger, IMapper mapper, IProcedureService iProcedureService)
        {
            _logger = logger;
            _iProcedureService = iProcedureService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "Getprocedures")]
        public async Task<IEnumerable<ProcedureViewModel>> Get()
        {
            return _mapper.Map<List<ProcedureViewModel>>(await _iProcedureService.GetProcedures()); 
        }
    }
}
