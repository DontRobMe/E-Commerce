using E_Commerce.Business.DTO;
using E_Commerce.Business.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Business.Models;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturesController : ControllerBase
    {
        private readonly ILogger<FacturesController> _logger;
        private readonly IFactureService _factureService;

        public FacturesController(ILogger<FacturesController> logger, IFactureService factureService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _factureService = factureService ?? throw new ArgumentNullException(nameof(factureService));
        }
        
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetFactureById(int id)
        {
            var facture = await _factureService.GetFactureById(id);
            return Ok(facture);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFacture(FactureDto factureDto)
        {
            await _factureService.AddFacture(factureDto);
            return Ok();
        }
        
        [HttpGet("getf/{id}")]
        public async Task<IActionResult> GetFactureByIdf(int id)
        {
            var facture = await _factureService.GetFactureByIdf(id);
            return Ok(facture);
        }
    }
}