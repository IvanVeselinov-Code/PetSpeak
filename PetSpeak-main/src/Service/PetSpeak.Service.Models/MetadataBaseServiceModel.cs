namespace PetSpeak.Service.Models
{
    public abstract class MetadataBaseServiceModel : BaseServiceModel
    {
        public PetSpeakUserServiceModel CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public PetSpeakUserServiceModel? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public PetSpeakUserServiceModel? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
