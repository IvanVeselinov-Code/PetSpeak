using Microsoft.AspNetCore.Identity;

namespace PetSpeak.Service.Models
{
    public class PetSpeakUserServiceModel : IdentityUser
    {
        public PetSpeakRoleServiceModel ForumRole { get; set; }
    }
}
