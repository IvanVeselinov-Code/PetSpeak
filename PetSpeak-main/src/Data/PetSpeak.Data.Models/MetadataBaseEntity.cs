namespace PetSpeak.Data.Models
{
    public abstract class MetadataBaseEntity : BaseEntity
    {
        public PetSpeakUser CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public PetSpeakUser? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public PetSpeakUser? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
