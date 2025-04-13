using PetSpeak.Data.Models;
using PetSpeak.Web.Data;
using Microsoft.AspNetCore.Http;

namespace PetSpeak.Data.Repositories
{
    public class ReactionRepository : MetadataBaseGenericRepository<Reaction>
    {
        public ReactionRepository(PetSpeakDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, httpContextAccessor)
        {
        }
    }
}
