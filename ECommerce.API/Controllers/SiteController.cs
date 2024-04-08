using E_Commerce.Busines.IServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteController : ControllerBase
    {
        private readonly ILogger<SiteController> _logger;
        private readonly ISiteService _projectService;
        public SiteController(ILogger<SiteController> logger,ISiteService projectService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }
    }   
}