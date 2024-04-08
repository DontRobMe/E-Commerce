using E_Commerce.Busines.IServices;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminService _projectService;
        
        public AdminController(ILogger<AdminController> logger,IAdminService projectService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }
    }   
}