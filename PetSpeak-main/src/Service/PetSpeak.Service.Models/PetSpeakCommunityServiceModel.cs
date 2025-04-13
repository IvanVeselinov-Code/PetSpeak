namespace PetSpeak.Service.Models
{
    public class PetSpeakCommunityServiceModel : MetadataBaseServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<PetSpeakTagServiceModel> Tags { get; set; }

        public AttachmentServiceModel ThumbnailPhoto { get; set; }

        public AttachmentServiceModel BannerPhoto { get; set; }
    }
}
