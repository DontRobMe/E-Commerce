using E_Commerce.Business.DTO;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AchatsController : ControllerBase
    {
        private readonly ILogger<AchatsController> _logger;
        private readonly IAchatsService _achatsService;
        
        public AchatsController(ILogger<AchatsController> logger,IAchatsService achatsService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _achatsService = achatsService ?? throw new ArgumentNullException(nameof(achatsService));
        }
        
        [HttpGet]
        public IActionResult GetAchats()
        {
            var users = _achatsService.GetAchats();
            return Ok(users);
        }

        [HttpGet("{id:long}", Name = "GetAchatById")]
        public IActionResult GetAchatById(long id)
        {
            var user = _achatsService.GetAchatById(id);
            if (user == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable.");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateAchat(AchatsDto.CreateAchatsDto achat)
        {
            Achats achatD = new Achats()
            {
                Produit = achat.Produit,
                Facture = achat.Facture,
                prix = achat.prix,
                quantité = achat.quantité,
                Date = achat.Date    
            };
            var createdUser = _achatsService.CreateAchat(achatD);
            if (!createdUser.IsSuccess)
            {
                return BadRequest("Erreur lors de la création de l'utilisateur.");
            }
            return CreatedAtRoute("GetAchatById", new { id = achatD.Id }, achatD);
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteAchat(long id)
        {
            var result = _achatsService.DeleteAchat(id);
            if (result == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la suppression.");
            }
            return NoContent();
        }
    }
}
