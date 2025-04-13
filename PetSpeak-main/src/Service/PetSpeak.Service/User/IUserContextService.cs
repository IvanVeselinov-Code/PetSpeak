using PetSpeak.Data.Models;

namespace PetSpeak.Service.User
{
    public interface IUserContextService
    {
        Task<PetSpeakUser> GetCurrentUserAsync();
    }
}
