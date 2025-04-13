using PetSpeak.Data.Models;
using PetSpeak.Data.Repositories;
using PetSpeak.Service.Mappings;
using PetSpeak.Service.Models;
using PetSpeak.Service.User;
using Microsoft.EntityFrameworkCore;

namespace PetSpeak.Service.Thread
{
    public class PetSpeakThreadService : IPetSpeakThreadService
    {
        private readonly PetSpeakThreadRepository PetSpeakThreadRepository;

        private readonly PetSpeakTagRepository PetSpeakTagRepository;

        private readonly PetSpeakCommunityRepository PetSpeakCommunityRepository;

        private readonly CommentRepository commentRepository;

        private readonly ReactionRepository reactionRepository;

        private readonly UserThreadReactionRepository userThreadReactionRepository;

        private readonly IUserContextService userContextService;

        public PetSpeakThreadService(
            PetSpeakThreadRepository PetSpeakThreadRepository,
            PetSpeakTagRepository PetSpeakTagRepository,
            PetSpeakCommunityRepository PetSpeakCommunityRepository,
            CommentRepository commentRepository,
            IUserContextService userContextService,
            ReactionRepository reactionRepository,
            UserThreadReactionRepository userThreadReactionRepository)
        {
            this.PetSpeakThreadRepository = PetSpeakThreadRepository;
            this.PetSpeakTagRepository = PetSpeakTagRepository;
            this.PetSpeakCommunityRepository = PetSpeakCommunityRepository;
            this.commentRepository = commentRepository;
            this.userContextService = userContextService;
            this.reactionRepository = reactionRepository;
            this.userThreadReactionRepository = userThreadReactionRepository;
        }

        public async Task<PetSpeakThreadServiceModel> CreateAsync(PetSpeakThreadServiceModel model)
        {
            PetSpeakThread PetSpeakThread = model.ToEntity();

            PetSpeakThread.Tags = PetSpeakThread.Tags.Select(async tag => {
                return (await this.PetSpeakTagRepository.CreateAsync(tag));
            }).Select(t => t.Result).ToList();

            PetSpeakThread.Community = await this.PetSpeakCommunityRepository.GetAll()
                .SingleOrDefaultAsync(community => community.Id == model.Community.Id);

            await PetSpeakThreadRepository.CreateAsync(PetSpeakThread);

            return PetSpeakThread.ToModel();
        }

        public async Task<CommentServiceModel> CreateCommentOnThread(CommentServiceModel commentServiceModel, string threadId, string? parentCommentId = null)
        {
            Data.Models.Comment entity = commentServiceModel.ToEntity();

            if (parentCommentId != null)
            {
                Data.Models.Comment? parent = await commentRepository.GetAll()
                    .SingleOrDefaultAsync(c => c.Id == parentCommentId);

                if (parent == null)
                {
                    throw new ArgumentException("Parent comment not found for id - " + parentCommentId);
                }

                entity.Parent = parent;
            }

            entity = await this.commentRepository.CreateAsync(entity);

            PetSpeakThread commentThread = await this.InternalGetByIdAsync(threadId);

            commentThread.Comments.Add(new UserThreadComment
            {
                Comment = entity,
                Thread = commentThread,
                User = (await this.userContextService.GetCurrentUserAsync())
            });

            await this.PetSpeakThreadRepository.UpdateAsync(commentThread);

            return entity.ToModel(CommentMappingsContext.Reaction);
        }

        public async Task<UserThreadReactionServiceModel> CreateReactionOnThread(string threadId, string reactionId)
        {
            PetSpeakThread reactionThread = await this.PetSpeakThreadRepository
                .GetAll()
                .Include(t => t.Reactions)
                    .ThenInclude(utr => utr.Reaction)
                        .ThenInclude(r => r.Emote)
                .Include(t => t.Reactions)
                    .ThenInclude(utr => utr.User)
                .SingleOrDefaultAsync(t => t.Id == threadId);

            PetSpeakUser user = await this.userContextService.GetCurrentUserAsync();

            UserThreadReaction existentReaction = reactionThread.Reactions
                .SingleOrDefault(utr => utr.Reaction.Id == reactionId && utr.User.Id == user.Id);

            if (existentReaction != null)
            {
                await this.userThreadReactionRepository.DeleteAsync(existentReaction);

                return existentReaction.ToModel(UserThreadReactionMappingsContext.User, true);
            }

            Data.Models.Reaction reaction = await reactionRepository.GetAll()
                .SingleOrDefaultAsync(r => r.Id == reactionId);

            var utr = new UserThreadReaction
            {
                Reaction = reaction,
                Thread = reactionThread,
                User = user
            };

            reactionThread.Reactions.Add(utr);

            await this.PetSpeakThreadRepository.UpdateAsync(reactionThread);
            
            return utr.ToModel(UserThreadReactionMappingsContext.User);
        }

        public Task<PetSpeakThreadServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PetSpeakThreadServiceModel> GetAll()
        {
            return this.InternalGetAll()
                .Select(t => t.ToModel());
        }

        public IQueryable<PetSpeakThreadServiceModel> GetAllByCommunityId(string communityId)
        {
            return this.InternalGetAll().Where(t => t.Community.Id == communityId).Select(t => t.ToModel());
        }

        public async Task<PetSpeakThreadServiceModel> GetByIdAsync(string id)
        {
            return (await this.InternalGetAll().SingleOrDefaultAsync(thread => thread.Id == id))?.ToModel();
        }

        public Task<PetSpeakThreadServiceModel> UpdateAsync(string id, PetSpeakThreadServiceModel model)
        {
            throw new NotImplementedException();
        }

        private async Task<PetSpeakThread> InternalGetByIdAsync(string id)
        {
            return await this.InternalGetAll().SingleOrDefaultAsync(thread => thread.Id == id);
        }

        private IQueryable<PetSpeakThread> InternalGetAll()
        {
            return PetSpeakThreadRepository.GetAll()
                .Include(t => t.Tags)
                .Include(t => t.Community)
                    .ThenInclude(c => c.ThumbnailPhoto)
                .Include(t => t.Reactions)
                    .ThenInclude(utr => utr.Reaction)
                        .ThenInclude(r => r.Emote)
                .Include(t => t.Attachments)
                .Include(t => t.Comments)
                .Include(t => t.CreatedBy)
                .Include(t => t.UpdatedBy)
                .Include(t => t.DeletedBy);
        }
    }
}
