using Microsoft.AspNetCore.Identity;

namespace PetSpeak.Data.Models
{
    public class PetSpeakUser : IdentityUser
    {
        public PetSpeakRole? ForumRole { get; set; }
    }
}
