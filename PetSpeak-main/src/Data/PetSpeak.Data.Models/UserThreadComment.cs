namespace PetSpeak.Data.Models
{
    public class UserThreadComment : BaseEntity
    {
        public PetSpeakUser User { get; set; }

        public PetSpeakThread Thread { get; set; }

        public Comment Comment { get; set; }
    }
}
