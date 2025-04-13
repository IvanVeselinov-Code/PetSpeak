using PetSpeak.Data.Models;
using PetSpeak.Service.Models;
using System.Reflection.Emit;

namespace PetSpeak.Service.Mappings
{
    public static class PetSpeakTagMappings
    {
        public static PetSpeakTag ToEntity(this PetSpeakTagServiceModel model)
        {
            return new PetSpeakTag
            {
                Label = model.Label
            };
        }

        public static PetSpeakTagServiceModel ToModel(this PetSpeakTag entity)
        {
            return new PetSpeakTagServiceModel
            {
                Id = entity.Id,
                Label = entity.Label,
                CreatedOn = entity.CreatedOn,
                UpdatedOn = entity.UpdatedOn,
                DeletedOn = entity.DeletedOn,
                CreatedBy = entity.CreatedBy.ToModel(),
                UpdatedBy = entity.UpdatedBy?.ToModel(),
                DeletedBy = entity.DeletedBy?.ToModel()
            };
        }
    }
}
