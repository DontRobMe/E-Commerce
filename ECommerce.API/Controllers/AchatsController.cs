using E_Commerce.Busines.IServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AchatsController : ControllerBase
    {
        private readonly ILogger<AchatsController> _logger;
        private readonly IAchatsService _projectService;
        
        public AchatsController(ILogger<AchatsController> logger,IAchatsService projectService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }
    }
}
