using PetSpeak.Data.Models;
using PetSpeak.Service.Models;

namespace PetSpeak.Service.Mappings
{
    public static class PetSpeakUserMappings
    {
        public static PetSpeakUser ToEntity(this PetSpeakUserServiceModel model)
        {
            return new PetSpeakUser(); // TODO: Verify if we actually need this
        }

        public static PetSpeakUserServiceModel ToModel(this PetSpeakUser entity)
        {
            return new PetSpeakUserServiceModel
            {
                ForumRole = entity.ForumRole?.ToModel(),
                Email = entity.Email,
                Id = entity.Id,
                UserName = entity.UserName
            };
        }
    }
}
