namespace PetSpeak.Data.Models
{
    public class PetSpeakCommunity : MetadataBaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        // Threads in this community can only hold the community tags
        public List<PetSpeakTag> Tags { get; set; }

        public Attachment? ThumbnailPhoto { get; set; }
        
        public Attachment? BannerPhoto { get; set; }
    }
}
