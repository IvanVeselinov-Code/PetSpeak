namespace PetSpeak.Service.Models
{
    public class UserThreadCommentServiceModel : BaseServiceModel
    {
        public PetSpeakUserServiceModel User { get; set; }

        public PetSpeakThreadServiceModel Thread { get; set; }

        public CommentServiceModel Comment { get; set; }
    }
}
