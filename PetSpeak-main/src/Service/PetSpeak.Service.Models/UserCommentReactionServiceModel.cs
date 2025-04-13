namespace PetSpeak.Service.Models
{
    public class UserCommentReactionServiceModel : BaseServiceModel
    {
        public PetSpeakUserServiceModel User { get; set; }

        public CommentServiceModel Comment { get; set; }

        public ReactionServiceModel Reaction { get; set; }

        public bool IsDeleted { get; set; }
    }
}
