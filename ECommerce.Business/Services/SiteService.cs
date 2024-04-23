using E_Commerce.Business.IRepositories;
using E_Commerce.Business.IServices;

namespace E_Commerce.Business.Services;

public class SiteService : ISiteService
{
    private readonly ISiteRepository _siteRepository;

    public SiteService(ISiteRepository siteRepository)
    {
        _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
    }
    
}