using E_Commerce.Business.DTO;
using E_Commerce.Business.IRepositories;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProduitRepository _produitRepository;

        public ClientService(IClientRepository clientRepository, IProduitRepository produitRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _produitRepository = produitRepository ?? throw new ArgumentNullException(nameof(produitRepository));
        }

        public BusinessResult<IEnumerable<Clients>> GetClients()
        {
            var users = _clientRepository.GetClients();
            return BusinessResult<IEnumerable<Clients>>.FromSuccess(users);
        }

        public BusinessResult<Clients> GetClientById(long id)
        {
            var user = _clientRepository.GetClientById(id);
            return BusinessResult<Clients>.FromSuccess(user);
        }

        public BusinessResult UpdateClient(long id, Clients model)
        {
            var updatedUser = _clientRepository.UpdateClient(id, model);
            return BusinessResult.FromSuccess(updatedUser);
        }


        public BusinessResult DeleteClient(long id)
        {
            _clientRepository.DeleteClient(id);
            return BusinessResult.FromSuccess();
        }

        public BusinessResult UpdatePassword(long id, string password)
        {
            var user = _clientRepository.GetClientById(id);
            user.Password = password;
            _clientRepository.UpdateClient(id, user);
            return BusinessResult.FromSuccess();
        }

        public BusinessResult Login(string email, string password)
        {
            var user = _clientRepository.Login(email, password);
            if (!user.IsSuccess)
            {
                return BusinessResult.FromError(user.Message, user.Error);
            }

            return BusinessResult.FromSuccess(user.Token);
        }

        public BusinessResult Register(Clients newUser)
        {
            var registrationResult = _clientRepository.Register(newUser);

            if (!registrationResult.IsSuccess)
            {
                return BusinessResult.FromError(registrationResult.Message, registrationResult.Error);
            }

            return BusinessResult.FromSuccess(registrationResult.Token);
        }

        public BusinessResult AddToWishlist(int userId, int productId)
        {
            var user = _clientRepository.GetClientById(userId);
            if (user == null)
            {
                return BusinessResult.FromError("User not found");
            }

            var produit = _produitRepository.GetProduitById(productId);
            if (produit == null)
            {
                return BusinessResult.FromError($"Product with ID {productId} not found");
            }

            var wishlistItem = new WishlistItem
            {
                ClientId = userId,
                ProduitId = produit.Id,
                Produit = produit
            };

            var result = _clientRepository.AddToWishlist(userId, wishlistItem);
            if (!result.IsSuccess)
            {
                return BusinessResult.FromError(result.Message, result.Error);
            }

            return BusinessResult.FromSuccess();
        }


        public BusinessResult<List<ProduitDto.WishlistProductDto>> GetWishlist(long userId)
        {
            var result = _clientRepository.GetWishlist(userId);
            if (!result.IsSuccess)
            {
                return BusinessResult<List<ProduitDto.WishlistProductDto>>.FromError(result.Message, result.Error);
            }

            return BusinessResult<List<ProduitDto.WishlistProductDto>>.FromSuccess(result.Result);
        }
        
        public BusinessResult RemoveFromWishlist(int userId, int productId)
        {
            var result = _clientRepository.RemoveFromWishlist(userId, productId);
            if (!result.IsSuccess)
            {
                return BusinessResult.FromError(result.Message, result.Error);
            }

            return BusinessResult.FromSuccess();
        }
    }
}