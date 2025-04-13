using PetSpeak.Data.Models;
using PetSpeak.Service.Models;

namespace PetSpeak.Service.Mappings
{
    public static class PetSpeakCommunityMappings
    {
        public static PetSpeakCommunity ToEntity(this PetSpeakCommunityServiceModel model)
        {
            return new PetSpeakCommunity
            {
                Name = model.Name,
                Description = model.Description,
                Tags = model.Tags?.Select(tag => tag.ToEntity()).ToList(),
                ThumbnailPhoto = model.ThumbnailPhoto?.ToEntity(),
                BannerPhoto = model.BannerPhoto?.ToEntity()
            };
        }

        public static PetSpeakCommunityServiceModel ToModel(this PetSpeakCommunity entity)
        {
            return new PetSpeakCommunityServiceModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Tags = entity.Tags?.Select(tag => tag.ToModel()).ToList(),
                ThumbnailPhoto = entity.ThumbnailPhoto?.ToModel(),
                BannerPhoto = entity.BannerPhoto?.ToModel(),
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
