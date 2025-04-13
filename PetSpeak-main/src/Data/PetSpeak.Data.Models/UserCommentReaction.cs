namespace PetSpeak.Data.Models
{
    public class UserCommentReaction : BaseEntity
    {
        public PetSpeakUser User { get; set; }

        public Comment Comment { get; set; }

        public Reaction Reaction { get; set; }
    }
}
