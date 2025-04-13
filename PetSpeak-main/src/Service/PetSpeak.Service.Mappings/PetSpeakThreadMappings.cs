using PetSpeak.Data.Models;
using PetSpeak.Service.Models;

namespace PetSpeak.Service.Mappings
{
    public static class PetSpeakThreadMappings
    {
        public static PetSpeakThread ToEntity(this PetSpeakThreadServiceModel model)
        {
            return new PetSpeakThread
            {
                Title = model.Title,
                Content = model.Content,
                Community = model.Community?.ToEntity(),
                Attachments = model.Attachments.Select(a => a.ToEntity()).ToList(),
                Tags = model.Tags?.Select(tag => tag.ToEntity()).ToList(),
            };
        }

        public static PetSpeakThreadServiceModel ToModel(this PetSpeakThread entity)
        {
            return new PetSpeakThreadServiceModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                Community = entity.Community?.ToModel(),
                Tags = entity.Tags?.Select(tag => tag.ToModel()).ToList(),
                Attachments = entity.Attachments?.Select(attachment => attachment.ToModel()).ToList(),
                Reactions = entity.Reactions?.Select(reaction => reaction.ToModel(UserThreadReactionMappingsContext.Thread)).ToList(),
                Comments = entity.Comments?.Select(comment => comment.ToModel(UserThreadCommentMappingsContext.Thread)).ToList(),
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
