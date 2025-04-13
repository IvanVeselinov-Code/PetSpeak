using PetSpeak.Data.Models;
using PetSpeak.Service.Models;

namespace PetSpeak.Service.Thread
{
    public interface IPetSpeakThreadService : IGenericService<PetSpeakThread, PetSpeakThreadServiceModel>
    {
        Task<CommentServiceModel> CreateCommentOnThread(CommentServiceModel commentServiceModel, string threadId, string? parentCommentId = null);

        Task<UserThreadReactionServiceModel> CreateReactionOnThread(string threadId, string reactionId);

        IQueryable<PetSpeakThreadServiceModel> GetAllByCommunityId(string communityId);
    }
}
