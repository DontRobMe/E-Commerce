using E_Commerce.Business.IRepositories;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
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

        public BusinessResult UpdateWallet(long id, int amount)
        {
            var user = _clientRepository.GetClientById(id);
            user.Wallet += amount;
            _clientRepository.UpdateClient(id, user);
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
            return BusinessResult.FromSuccess(user);
        }

        public BusinessResult Register(Clients newUser)
        {
            var registrationResult = _clientRepository.Register(newUser);
    
            if (!registrationResult.IsSuccess)
            {
                return BusinessResult.FromError(registrationResult.Message, registrationResult.Error);
            }
            return BusinessResult.FromSuccess();
        }
    }
}