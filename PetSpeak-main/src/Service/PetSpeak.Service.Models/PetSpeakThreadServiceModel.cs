namespace PetSpeak.Service.Models
{
    public class PetSpeakThreadServiceModel : MetadataBaseServiceModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public List<AttachmentServiceModel> Attachments { get; set; }

        public PetSpeakCommunityServiceModel Community { get; set; }

        public List<PetSpeakTagServiceModel> Tags { get; set; }

        public List<UserThreadReactionServiceModel> Reactions { get; set; }

        public List<UserThreadCommentServiceModel> Comments { get; set; }
    }
}
