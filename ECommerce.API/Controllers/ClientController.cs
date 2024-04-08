using E_Commerce.Busines.IServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _projectService;
        public ClientController(ILogger<ClientController> logger,IClientService projectService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }
    }   
}