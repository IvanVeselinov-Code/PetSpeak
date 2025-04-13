using PetSpeak.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PetSpeak.Service.User
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserStore<PetSpeakUser> userStore;

        public UserContextService(
            IHttpContextAccessor httpContextAccessor, 
            IUserStore<PetSpeakUser> userStore)
        {
            _httpContextAccessor = httpContextAccessor;
            this.userStore = userStore;
        }

        public async Task<PetSpeakUser> GetCurrentUserAsync()
        {
            string? userId = this._httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await this.userStore.FindByIdAsync(userId, CancellationToken.None);
        }
    }
}
