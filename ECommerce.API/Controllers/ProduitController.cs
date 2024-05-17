using E_Commerce.Business.DTO;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduitController : ControllerBase
    {
        private readonly ILogger<ProduitController> _logger;
        private readonly IProduitService _produitService;

        public ProduitController(ILogger<ProduitController> logger, IProduitService produitService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _produitService = produitService ?? throw new ArgumentNullException(nameof(produitService));
        }

        [HttpGet("GetProduits")]
        public IActionResult GetProduits()
        {
            var users = _produitService.GetProduits();
            return Ok(users);
        }

        [HttpGet("{id:long}", Name = "GetProduitById")]
        public IActionResult GetProduitById(long id)
        {
            var user = _produitService.GetProduitById(id);
            if (user == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable.");
            }

            return Ok(user);
        }

        [HttpPost("CreateProduit")]
        public IActionResult CreateProduit(ProduitDto.CreateProduitDto user)
        {
            Produit userD = new Produit()
            {
                Name = user.Name,
                Description = user.Description,
                Price = user.Price,
                Stock = user.Stock,
                Image = user.Image,
                Category = user.Category,
                Rating = user.Rating,
                productcodes = user.productcodes
            };
            var createdUser = _produitService.CreateProduit(userD);
            if (!createdUser.IsSuccess)
            {
                return BadRequest("Produit déjà existant.");
            }

            return Ok(createdUser);
        }

        [HttpPut("{id:long}")]
        public IActionResult UpdateProduit(long id, ClientDto.UpdateClientDto user)
        {
            Produit userD = new Produit()
            {
                Name = user.Name,
            };

            var updatedUser = _produitService.UpdateProduit(id, userD);
            if (updatedUser == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la mise à jour.");
            }

            return Ok(updatedUser);
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteProduit(long id)
        {
            var result = _produitService.DeleteProduit(id);
            if (result == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la suppression.");
            }

            return NoContent();
        }
        
        [HttpGet("{name}" , Name = "GetProduitByName")]
        public IActionResult GetProduitByName(string name)
        {
            var user = _produitService.GetProduitByName(name);
            if (user == null)
            {
                return NotFound($"Produit avec le nom {name} introuvable.");
            }

            return Ok(user);
        }
    }
}