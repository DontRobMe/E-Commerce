﻿using E_Commerce.Business.DTO;
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
        public ClientController(ILogger<ClientController> logger,IClientService clientService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }
        
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _clientService.GetClients();
            return Ok(users);
        }

        [HttpGet("{id:long}", Name = "GetClientById")]
        public IActionResult GetUserById(long id)
        {
            var user = _clientService.GetClientById(id);
            if (user == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable.");
            }
            return Ok(user);
        }

        [HttpPut("{id:long}")]
        public IActionResult UpdateUser(long id, ClientDto.UpdateClientDto user)
        {
            Clients userD = new Clients()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            };
            
            var updatedUser = _clientService.UpdateClient(id, userD);
            if (updatedUser == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la mise à jour.");
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteUser(long id)
        {
            var result = _clientService.DeleteClient(id);
            if (result == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la suppression.");
            }
            return NoContent();
        }
        
        
        
        [HttpPut("{id:long}/wallet")]
        public IActionResult UpdateWallet(long id, ClientDto.WalletClientDto wallet)
        {
            var updatedWallet = _clientService.UpdateWallet(id, wallet.Wallet);
            if (updatedWallet == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} introuvable pour la mise à jour du portefeuille.");
            }
            return Ok(updatedWallet);
        }
        
        [HttpPut("{id:long}/password")]
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
            if (user == null)
            {
                return NotFound("Utilisateur non trouvé.");
            }
            var loggedInResponse = new 
            {
                Message = "Connexion réussie.",
                User = user
            };

            return Ok(loggedInResponse);
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
                Password = user.Password
            };
            var createdUser = _clientService.Register(userD);
            if (!createdUser.IsSuccess)
            {
                return BadRequest("le client existe deja");
            }
            return Ok(createdUser);
        }
    }   
}