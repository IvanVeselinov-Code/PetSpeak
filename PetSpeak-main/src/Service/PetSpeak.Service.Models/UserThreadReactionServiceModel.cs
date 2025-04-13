namespace PetSpeak.Service.Models
{
    public class UserThreadReactionServiceModel : BaseServiceModel
    {
        public PetSpeakUserServiceModel User { get; set; }

        public PetSpeakThreadServiceModel Thread { get; set; }

        public ReactionServiceModel Reaction { get; set; }

        public bool IsDeleted { get; set; }
    }
}
