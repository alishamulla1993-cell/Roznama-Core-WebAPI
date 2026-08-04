using Roznama.Infrastructure.Logging;
using Roznama.Models.Auth;

namespace Roznama.Modules.Auth
{
    public class AuthService
    {
        private readonly AuthRepository _repo;

        public AuthService(AuthRepository repo)
        {
            _repo = repo;
        }

        public Task<LoginResponse?> LoginAsync(string username, string password)
        {
            try
            {
                return _repo.AuthenticateAsync(username, password);
            }
            catch (Exception ex)
            {
                LogHelper.Log("AuthService.LoginAsync: " + ex.Message);
                throw;
            }
        }
    }
}