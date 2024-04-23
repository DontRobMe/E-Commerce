using E_Commerce.Business.DTO;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminService _adminService;

        public AdminController(ILogger<AdminController> logger, IAdminService adminService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        [HttpGet]
        public IActionResult GetAdmins()
        {
            var users = _adminService.GetAdmins();
            return Ok(users);
        }

        [HttpGet("{id:long}", Name = "GetAdminById")]
        public IActionResult GetAdminById(long id)
        {
            var user = _adminService.GetAdminById(id);
            if (user == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable.");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateAdmin(AdminDto.CreateAdminDto user)
        {
            Admin userD = new Admin()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Birth = user.Birth
            };
            var createdUser = _adminService.CreateAdmin(userD);
            if (!createdUser.IsSuccess)
            {
                return BadRequest("Erreur lors de la création de l'utilisateur.");
            }

            return CreatedAtRoute("GetAdminById", new { id = userD.Id }, userD);
        }

        [HttpPut("{id:long}")]
        public IActionResult UpdateAdmin(long id, AdminDto.UpdateAdminDto user)
        {
            Admin userD = new Admin()
            {
                Name = user.Name,
            };

            var updatedUser = _adminService.UpdateAdmin(id, userD);
            if (updatedUser == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la mise à jour.");
            }

            return Ok(updatedUser);
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteAdmin(long id)
        {
            var result = _adminService.DeleteAdmin(id);
            if (result == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la suppression.");
            }

            return NoContent();
        }
    }
}