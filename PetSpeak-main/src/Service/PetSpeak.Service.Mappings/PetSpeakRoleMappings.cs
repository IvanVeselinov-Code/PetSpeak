using PetSpeak.Data.Models;
using PetSpeak.Service.Models;

namespace PetSpeak.Service.Mappings
{
    public static class PetSpeakRoleMappings
    {
        public static PetSpeakRole ToEntity(this PetSpeakRoleServiceModel model)
        {
            return new PetSpeakRole
            {
                Label = model.Label,
                Color = model.Color,
                Authority = model.Authority
            };
        }

        public static PetSpeakRoleServiceModel ToModel(this PetSpeakRole entity)
        {
            return new PetSpeakRoleServiceModel
            {
                Id = entity.Id,
                Label = entity.Label,
                Color = entity.Color,
                Authority = entity.Authority,
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
