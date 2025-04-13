using PetSpeak.Data.Models;
using PetSpeak.Service.Models;

namespace PetSpeak.Service.Mappings
{
    public static class AttachmentMapping
    {
        public static Attachment ToEntity(this AttachmentServiceModel model)
        {
            return new Attachment
            {
                CloudUrl = model.CloudUrl
            };
        }

        public static AttachmentServiceModel ToModel(this Attachment entity)
        {
            return new AttachmentServiceModel
            {
                Id = entity.Id,
                CloudUrl = entity.CloudUrl
            };
        }
    }
}
