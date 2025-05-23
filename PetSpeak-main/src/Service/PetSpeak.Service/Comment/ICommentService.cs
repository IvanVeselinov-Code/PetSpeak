﻿using PetSpeak.Service.Models;

namespace PetSpeak.Service.Comment
{
    public interface ICommentService : IGenericService<Data.Models.Comment, CommentServiceModel>
    {
        IQueryable<CommentServiceModel> GetAllByParentId(string parentId);

        Task<IQueryable<CommentServiceModel>> GetAllByThreadId(string threadId);

        Task<UserCommentReactionServiceModel> CreateReactionOnComment(string commentId, string reactionId);
    }
}
