using PetSpeak.Data.Models;
using PetSpeak.Web.Data;

namespace PetSpeak.Data.Repositories
{
    public class UserThreadReactionRepository : BaseGenericRepository<UserThreadReaction>
    {
        public UserThreadReactionRepository(PetSpeakDbContext dbContext) : base(dbContext)
        {
        }
    }
}
