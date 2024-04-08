using E_Commerce.Busines.IServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduitController : ControllerBase
    {
        private readonly ILogger<ProduitController> _logger;
        private readonly IProduitService _projectService;
        public ProduitController(ILogger<ProduitController> logger,IProduitService projectService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }
    }   
}