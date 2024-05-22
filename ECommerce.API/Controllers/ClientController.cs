using E_Commerce.Business.DTO;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var users = _clientService.GetClients();
            return Ok(users);
        }

        [HttpGet("getclient/{id:long}", Name = "GetClientById")]
        public IActionResult GetUserById(long id)
        {
            var user = _clientService.GetClientById(id);
            if (user.IsSuccess == false)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable.");
            }

            return Ok(user);
        }

        [HttpPut("updateuser/{id:long}")]
        public IActionResult UpdateUser(long id, ClientDto.UpdateClientDto user)
        {
            Clients userD = new Clients()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Birth = user.birth
            };

            var updatedUser = _clientService.UpdateClient(id, userD);
            if (updatedUser == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la mise à jour.");
            }

            return Ok(updatedUser);
        }

        [HttpDelete("deleteuser/{id:long}")]
        public IActionResult DeleteUser(long id)
        {
            var result = _clientService.DeleteClient(id);
            if (result == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la suppression.");
            }

            return NoContent();
        }
        
        [HttpPut("password/{id:long}")]
        public IActionResult UpdatePassword(long id, ClientDto.PasswordClientDto password)
        {
            var updatedPassword = _clientService.UpdatePassword(id, password.Password);
            if (updatedPassword == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la mise à jour du mot de passe.");
            }

            return Ok(updatedPassword);
        }

        [HttpPost("login")]
        public IActionResult Login(ClientDto.LoginClientDto login)
        {
            var user = _clientService.Login(login.Email, login.Password);
            if (user.IsSuccess == false)
            {
                return BadRequest("Email ou mot de passe incorrect.");
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register(ClientDto.RegisterClientDto user)
        {
            Clients userD = new Clients()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Password = user.Password,
                Birth = user.birth
            };
            var createdUser = _clientService.Register(userD);
            if (!createdUser.IsSuccess)
            {
                return BadRequest("le client existe deja");
            }
            return Ok(createdUser);
        }

        [HttpPost("addwishlist/{userId:long}")]
        public IActionResult AddToWishlist(int userId, [FromQuery(Name = "gameId")] int gameId)
        {
            var result = _clientService.AddToWishlist(userId, gameId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }


        [HttpGet("getwishlist/{id:long}")]
        public IActionResult GetWishlist(long id)
        {
            var result = _clientService.GetWishlist(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Result);
        }
        
        [HttpDelete("removewishlist/{userId:long}")]
        public IActionResult RemoveFromWishlist(int userId, [FromQuery(Name = "gameId")] int gameId)
        {
            var result = _clientService.RemoveFromWishlist(userId, gameId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }
        
        
        [HttpPost("addcart/{userId:long}")]
        public IActionResult AddToCart(int userId, [FromQuery(Name = "gameId")] int gameId)
        {
            var result = _clientService.AddToCart(userId, gameId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }


        [HttpGet("getcart/{id:long}")]
        public IActionResult GetCart(long id)
        {
            var result = _clientService.GetCart(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Result);
        }
        
        [HttpDelete("removecart/{userId:long}")]
        public IActionResult RemoveFromCart(int userId, [FromQuery(Name = "gameId")] int gameId)
        {
            var result = _clientService.RemoveFromCart(userId, gameId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }
    }
}