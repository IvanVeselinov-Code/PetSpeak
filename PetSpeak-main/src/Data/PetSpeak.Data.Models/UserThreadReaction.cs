namespace PetSpeak.Data.Models
{
    public class UserThreadReaction : BaseEntity
    {
        public PetSpeakUser User { get; set; }

        public PetSpeakThread Thread { get; set; }

        public Reaction Reaction { get; set; }
    }
}
