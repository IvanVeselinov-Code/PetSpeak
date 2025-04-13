namespace PetSpeak.Data.Models
{
    public class PetSpeakThread : MetadataBaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public List<Attachment> Attachments { get; set; }

        public PetSpeakCommunity Community { get; set; }

        public List<PetSpeakTag> Tags { get; set; }

        public List<UserThreadReaction> Reactions { get; set; }

        public List<UserThreadComment> Comments { get; set; }
    }
}
