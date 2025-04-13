using PetSpeak.Data.Models;
using PetSpeak.Web.Data;

namespace PetSpeak.Data.Repositories
{
    public class UserCommentReactionRepository : BaseGenericRepository<UserCommentReaction>
    {
        public UserCommentReactionRepository(PetSpeakDbContext dbContext) : base(dbContext)
        {
        }
    }
}
